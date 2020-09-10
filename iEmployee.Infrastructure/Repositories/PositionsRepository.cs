using iEmployee.CommandQuery;
using iEmployee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iEmployee.Infrastructure.Repositories
{

    public interface IPositionsRepository
    {
        Task<IEnumerable<Position>> GetPositions();
        Task<Position> GetPosition(Guid positionId);
        Task<bool> AddPositionAsync(Position position);
        Task<bool> DeletePosition(Guid positionId);
        Task<bool> UpdatePosition(Guid positionId, Position position);
        Task<IEnumerable<Position>> GetNotAssignedPosition(Guid employeeId);
    }
    public class PositionsRepository : IPositionsRepository
    {
        private readonly iEmployeeContext dbContext;
        public PositionsRepository(iEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddPositionAsync(Position position)
        {
            await this.dbContext.Positions.AddAsync(position);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePosition(Guid positionId)
        {
            Position position = this.dbContext.Positions.Find(positionId);
            this.dbContext.Positions.Remove(position);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Position>> GetNotAssignedPosition(Guid employeeId)
        {
            var except = this.dbContext.Positions.Include(x => x.JobHistories).Where(x => x.JobHistories.Where(j => j.EmployeeId == employeeId && j.EndDate == null).Any());
            return await this.dbContext.Positions.Include(x => x.JobHistories).Except(except).ToListAsync();
        }

        public async Task<Position> GetPosition(Guid positionId)
        {
            return await this.dbContext.Positions.FindAsync(positionId);
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await this.dbContext.Positions.ToListAsync();
        }

        public async Task<bool> UpdatePosition(Guid positionId, Position positionModel)
        {
            var position = this.dbContext.Positions.Find(positionId);
            position.Update(positionModel);
            this.dbContext.Positions.Update(position);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
