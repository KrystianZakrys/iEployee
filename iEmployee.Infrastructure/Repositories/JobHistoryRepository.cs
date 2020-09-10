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
    public interface IJobHistoryRepository
    {
        Task<JobHistory> GetJobHistory(Guid jobHistoryId);
        Task<bool> AddJobHistory(JobHistory jobHistory);
        Task<bool> DeleteJobHistory(Guid jobHistoryId);
        Task<IEnumerable<JobHistory>> GetJobHistoryForEmployee(Guid employeeId);
    }
    public class JobHistoryRepository : IJobHistoryRepository
    {
        private readonly iEmployeeContext dbContext;
        public JobHistoryRepository(iEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> AddJobHistory(JobHistory jobHistory)
        {
            await this.dbContext.JobHistories.AddAsync(jobHistory);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteJobHistory(Guid jobHistoryId)
        {
            JobHistory jobHistory = this.dbContext.JobHistories.Find(jobHistoryId);
            this.dbContext.SaveChanges();
            this.dbContext.JobHistories.Remove(jobHistory);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<JobHistory> GetJobHistory(Guid jobHistoryId)
        {
            return await this.dbContext.JobHistories.Include(x => x.Employee).Include(x => x.Position).FirstOrDefaultAsync(x => x.Id.Equals(jobHistoryId));
        }

        public async Task<IEnumerable<JobHistory>> GetJobHistoryForEmployee(Guid employeeId)
        {
            return await this.dbContext.JobHistories.Where(x => x.Employee.Id == employeeId).ToListAsync();
        }

    }
}
