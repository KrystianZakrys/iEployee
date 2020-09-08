using iEmployee.CommandQuery;
using iEmployee.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEmployee.Infrastructure.Repositories
{
    public interface IManagersRepository
    {
        Task<IEnumerable<Manager>> GetManagers();
        Task<Manager> GetManager(Guid managerId);
        Task<bool> AddManagerAsync(Manager manager);
        Task<bool> DeleteManager(Guid managerId);
        Task<bool> UpdateManager(Guid managerId, Manager manager);

    }
    public class ManagersRepository : IManagersRepository
    {
        private readonly iEmployeeContext dbContext;

        public ManagersRepository(iEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddManagerAsync(Manager manager)
        {
            await this.dbContext.Managers.AddAsync(manager);
            this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteManager(Guid managerId)
        {
            Manager manager = this.dbContext.Managers.Include(x => x.Suboridnates).Include(x => x.Employee).FirstOrDefault(x => x.Id.Equals(managerId));
            manager.ClearSubordinates();
            this.dbContext.SaveChanges();
            this.dbContext.Managers.Remove(manager);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Manager> GetManager(Guid managerId)
        {
            return await this.dbContext.Managers.FindAsync(managerId);
        }

        public async Task<IEnumerable<Manager>> GetManagers()
        {
            return await this.dbContext.Managers.Include(x => x.Employee).Include(x => x.Suboridnates).ToListAsync();
        }

        public async Task<bool> UpdateManager(Guid managerId, Manager managerModel)
        {
            var manager = this.dbContext.Managers.Find(managerId);
            manager.Update(managerModel);
            this.dbContext.Managers.Update(manager);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
