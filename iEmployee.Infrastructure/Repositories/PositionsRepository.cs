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
    /// <summary>
    /// Interface for Position Repository
    /// </summary>
    public interface IPositionsRepository
    {
        /// <summary>
        /// Gets list of positions
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Position>> GetPositions();
        /// <summary>
        /// Gets position
        /// </summary>
        /// <param name="positionId">position identifier</param>
        /// <returns></returns>
        Task<Position> GetPosition(Guid positionId);
        /// <summary>
        /// Adds position
        /// </summary>
        /// <param name="position">position entity</param>
        /// <returns></returns>
        Task<bool> AddPositionAsync(Position position);
        /// <summary>
        /// Deletes position
        /// </summary>
        /// <param name="positionId">position identifier</param>
        /// <returns></returns>
        Task<bool> DeletePosition(Guid positionId);
        /// <summary>
        /// Updates position
        /// </summary>
        /// <param name="positionId">position identifier</param>
        /// <param name="position">position updated entity</param>
        /// <returns></returns>
        Task<bool> UpdatePosition(Position position);
        /// <summary>
        /// Gets positions not assigned to specified employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        Task<IEnumerable<Position>> GetNotAssignedPosition(Guid employeeId);
    }
    /// <summary>
    /// Implementation of IPositionRepository
    /// </summary>
    /// <seealso cref="IPositionsRepository"/>
    public class PositionsRepository : IPositionsRepository
    {
        private readonly EmployeeContext dbContext;
        public PositionsRepository(EmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Adds position
        /// </summary>
        /// <param name="position">position entity</param>
        /// <returns></returns>
        public async Task<bool> AddPositionAsync(Position position)
        {
            await dbContext.Positions.AddAsync(position);
            return true;
        }
        /// <summary>
        /// Deletes position
        /// </summary>
        /// <param name="positionId">position identifier</param>
        /// <returns></returns>
        public async Task<bool> DeletePosition(Guid positionId)
        {
            Position position = dbContext.Positions.Find(positionId);
            dbContext.Positions.Remove(position);
            return true;
        }
        /// <summary>
        /// Gets positions not assigned to specified employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        public async Task<IEnumerable<Position>> GetNotAssignedPosition(Guid employeeId)
        {
            var except = dbContext.Positions.Include(x => x.JobHistories).Where(x => x.JobHistories.Where(j => j.EmployeeId == employeeId && j.EndDate == null).Any());
            return await dbContext.Positions.Include(x => x.JobHistories).Except(except).ToListAsync();
        }
        /// <summary>
        /// Gets position
        /// </summary>
        /// <param name="positionId">position identifier</param>
        /// <returns></returns>
        public async Task<Position> GetPosition(Guid positionId)
        {
            return await dbContext.Positions.FindAsync(positionId);
        }
        /// <summary>
        /// Gets list of positions
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await dbContext.Positions.ToListAsync();
        }
        /// <summary>
        /// Updates position
        /// </summary>
        /// <param name="position">position updated entity</param>
        /// <returns></returns>
        public async Task<bool> UpdatePosition(Position position)
        {
            dbContext.Positions.Update(position);
            return true;
        }
    }
}
