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
    /// Interface for Projects Repository
    /// </summary>
    public interface IProjectsRepository
    {
        /// <summary>
        /// Gets projects list
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjects();
        /// <summary>
        /// Gets project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        Task<Project> GetProject(Guid projectId);
        /// <summary>
        /// Gets project including assigned employees
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<Project> GetProjectWithEmployees(Guid projectId);
        /// <summary>
        /// Adds project
        /// </summary>
        /// <param name="project">project entity</param>
        /// <returns></returns>
        Task<bool> AddProjectAsync(Project project);
        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        Task<bool> DeleteProject (Guid projectId);
        /// <summary>
        /// Updates project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <param name="project">project updated identity</param>
        /// <returns></returns>
        Task<bool> UpdateProject(Project project);
        /// <summary>
        /// Gets projects list for specified employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetEmployeeProjects(Guid employeeId);
        /// <summary>
        /// Gets list of projects not assigned to specified employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetNotAssignedProjects(Guid employeeId);
    }
    /// <summary>
    /// Implementation of IProjectsRepository
    /// </summary>
    /// <seealso cref="IProjectsRepository"/>
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly EmployeeContext dbContext;
        public ProjectsRepository(EmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Adds project
        /// </summary>
        /// <param name="project">project entity</param>
        /// <returns></returns>
        public async Task<bool> AddProjectAsync(Project project)
        {
            await dbContext.Projects.AddAsync(project);
            return true;
        }
        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        public async Task<bool> DeleteProject(Guid projectId)
        {
            Project project = dbContext.Projects.Find(projectId);
            dbContext.Projects.Remove(project);
            return true;
        }
        /// <summary>
        /// Gets project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        public async Task<Project> GetProject(Guid projectId)
        {
            return await dbContext.Projects.FindAsync(projectId);
        }
        /// <summary>
        /// Gets project including assigned employees
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        public async Task<Project> GetProjectWithEmployees(Guid projectId)
        {
            return await dbContext.Projects.Include(x => x.Employees).ThenInclude(x => x.Employee).FirstOrDefaultAsync(x => x.Id == projectId);
        }
        /// <summary>
        /// Gets projects list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await dbContext.Projects.ToListAsync();
        }
        /// <summary>
        /// Gets projects list for specified employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        public async Task<IEnumerable<Project>> GetEmployeeProjects(Guid employeeId)
        {
            return await dbContext.Projects.Include(p =>p.Employees).Where(p => p.Employees.Select(e => e.EmployeeId).Contains(employeeId)).ToListAsync();
        }
        /// <summary>
        /// Gets list of projects not assigned to specified employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        public async Task<IEnumerable<Project>> GetNotAssignedProjects(Guid employeeId)
        {
            return await dbContext.Projects.Include(p => p.Employees).Where(p => !p.Employees.Select(e => e.EmployeeId).Contains(employeeId)).ToListAsync();
        }
        /// <summary>
        /// Updates project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <param name="project">project updated identity</param>
        /// <returns></returns>
        public async Task<bool> UpdateProject(Project project)
        {
            dbContext.Projects.Update(project);
            return true;
        }
    }
}
