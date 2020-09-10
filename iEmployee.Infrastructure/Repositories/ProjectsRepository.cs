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
    public interface IProjectsRepository
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(Guid projectId);
        Task<bool> AddProjectAsync(Project project);
        Task<bool> DeleteProject (Guid projectId);
        Task<bool> UpdateProject(Guid projectId, Project project);
        Task<IEnumerable<Project>> GetEmployeeProjects(Guid employeeId);
        Task<IEnumerable<Project>> GetNotAssignedProjects(Guid employeeId);
    }
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly iEmployeeContext dbContext;
        public ProjectsRepository(iEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddProjectAsync(Project project)
        {
            await this.dbContext.Projects.AddAsync(project);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            Project project = this.dbContext.Projects.Find(projectId);
            this.dbContext.Projects.Remove(project);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Project> GetProject(Guid projectId)
        {
            return await this.dbContext.Projects.Include(x => x.Employees).ThenInclude(x => x.Employee).FirstOrDefaultAsync(x => x.Id == projectId);
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await this.dbContext.Projects.ToListAsync();
        }


        public async Task<IEnumerable<Project>> GetEmployeeProjects(Guid employeeId)
        {
            return await this.dbContext.Projects.Include(p =>p.Employees).Where(p => p.Employees.Select(e => e.EmployeeId).Contains(employeeId)).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetNotAssignedProjects(Guid employeeId)
        {
            return await this.dbContext.Projects.Include(p => p.Employees).Where(p => !p.Employees.Select(e => e.EmployeeId).Contains(employeeId)).ToListAsync();
        }

        public async Task<bool> UpdateProject(Guid projectId, Project projectModel)
        {
            var project = this.dbContext.Projects.Find(projectId);
            project.Update(projectModel);
            this.dbContext.Projects.Update(project);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
