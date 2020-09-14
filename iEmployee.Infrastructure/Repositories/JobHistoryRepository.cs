using iEmployee.CommandQuery;
using iEmployee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEmployee.Infrastructure.Repositories
{
    /// <summary>
    /// Job histories repository
    /// </summary>
    public interface IJobHistoryRepository
    {
        /// <summary>
        /// Gets job history
        /// </summary>
        /// <param name="jobHistoryId">job history identifier</param>
        /// <returns></returns>
        Task<JobHistory> GetJobHistory(Guid jobHistoryId);
        /// <summary>
        /// Adds job history entry
        /// </summary>
        /// <param name="jobHistory">job history entry entity</param>
        /// <returns></returns>
        Task<bool> AddJobHistory(JobHistory jobHistory);
        /// <summary>
        /// Deletes job history
        /// </summary>
        /// <param name="jobHistoryId">job history entry identifier</param>
        /// <returns></returns>
        Task<bool> DeleteJobHistory(Guid jobHistoryId);
        /// <summary>
        /// Gets job histories for employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        Task<IEnumerable<JobHistory>> GetJobHistoryForEmployee(Guid employeeId);
    }
    /// <summary>
    /// Implementation of IJobHistoryRepository
    /// </summary>
    /// <seealso cref="IJobHistoryRepository"/>
    public class JobHistoryRepository : IJobHistoryRepository
    {
        private readonly EmployeeContext dbContext;
        public JobHistoryRepository(EmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Adds job history entry
        /// </summary>
        /// <param name="jobHistory">job history entry entity</param>
        /// <returns></returns>
        public async Task<bool> AddJobHistory(JobHistory jobHistory)
        {
            await this.dbContext.JobHistories.AddAsync(jobHistory);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Deletes job history
        /// </summary>
        /// <param name="jobHistoryId">job history entry identifier</param>
        /// <returns></returns>
        public async Task<bool> DeleteJobHistory(Guid jobHistoryId)
        {
            JobHistory jobHistory = this.dbContext.JobHistories.Find(jobHistoryId);
            this.dbContext.SaveChanges();
            this.dbContext.JobHistories.Remove(jobHistory);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Gets job history
        /// </summary>
        /// <param name="jobHistoryId">job history identifier</param>
        /// <returns></returns>
        public async Task<JobHistory> GetJobHistory(Guid jobHistoryId)
        {
            return await this.dbContext.JobHistories.Include(x => x.Employee).Include(x => x.Position).FirstOrDefaultAsync(x => x.Id.Equals(jobHistoryId));
        }
        /// <summary>
        /// Gets job histories for employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        public async Task<IEnumerable<JobHistory>> GetJobHistoryForEmployee(Guid employeeId)
        {
            return await this.dbContext.JobHistories.Where(x => x.Employee.Id == employeeId).ToListAsync();
        }

    }
}
