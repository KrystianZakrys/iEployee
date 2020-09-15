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
    /// <summary>
    /// Interface for Managers Repository
    /// </summary>
    public interface IManagersRepository
    {
        /// <summary>
        /// Gets list of managers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Manager>> GetManagers();
        /// <summary>
        /// Gets manager
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        Task<Manager> GetManager(Guid managerId);
        /// <summary>
        /// Gets manager with subordinates
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        Task<Manager> GetManagerWithSubordinates(Guid managerId);
        /// <summary>
        /// Adds manager
        /// </summary>
        /// <param name="manager">manager entity</param>
        /// <returns></returns>
        Task<bool> AddManagerAsync(Manager manager);
        /// <summary>
        /// Delete manager
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        Task<bool> DeleteManager(Guid managerId);
        /// <summary>
        /// Updates manager entity data
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <param name="manager">manager updated entity </param>
        /// <returns></returns>
        Task<bool> UpdateManager(Manager manager);
    }
    /// <summary>
    /// Implements IManagersRepository
    /// </summary>
    /// <seealso cref="IManagersRepository"/>
    public class ManagersRepository : IManagersRepository
    {
        private readonly EmployeeContext dbContext;
        public ManagersRepository(EmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Adds manager
        /// </summary>
        /// <param name="manager">manager entity</param>
        /// <returns></returns>
        public async Task<bool> AddManagerAsync(Manager manager)
        {
            await dbContext.Managers.AddAsync(manager);
            return true;
        }
        /// <summary>
        /// Delete manager
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        public async Task<bool> DeleteManager(Guid managerId)
        {
            Manager manager = dbContext.Managers.Include(x => x.Subordinates).Include(x => x.Employee).FirstOrDefault(x => x.Id.Equals(managerId));
            manager.ClearSubordinates();
            dbContext.Managers.Remove(manager);
            return true;
        }
        /// <summary>
        /// Gets manager
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        public async Task<Manager> GetManager(Guid managerId)
        {
            return await dbContext.Managers.FindAsync(managerId);
        }  
        /// <summary>
        /// Gets manager with subordinates
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        public async Task<Manager> GetManagerWithSubordinates(Guid managerId)
        {
            return await dbContext.Managers.Include(x => x.Subordinates).Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == managerId);
        }
        /// <summary>
        /// Gets list of managers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Manager>> GetManagers()
        {
            return await dbContext.Managers.Include(x => x.Employee).Include(x => x.Subordinates).ToListAsync();
        }
        /// <summary>
        /// Updates manager entity data
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <param name="manager">manager updated entity </param>
        /// <returns></returns>
        public async Task<bool> UpdateManager(Manager manager)
        {
            dbContext.Managers.Update(manager);
            return true;
        }
    }
}
