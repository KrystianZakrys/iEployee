using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using iEmployee.CommandQuery;
using iEmployee.Contracts.Criteria;
using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace iEmployee.Infrastructure.Repositories
{
    /// <summary>
    /// Interface for Employee Repository
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Gets employees list
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployees();
        /// <summary>
        /// Gets employee
        /// </summary>
        /// <param name="employeeId">employeee identifier</param>
        /// <returns></returns>
        Task<Employee> GetEmployee(Guid employeeId);
        /// <summary>
        /// Gets employees satisfying criteria
        /// </summary>
        /// <param name="employeeCriteria">filtering criteria</param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployees(EmployeeCriteria employeeCriteria);
        /// <summary>
        /// Adds employee
        /// </summary>
        /// <param name="employee">employee entity</param>
        /// <returns></returns>
        Task<bool> AddEmployeeAsync(Employee employee);
        /// <summary>
        /// Deletes employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        Task<bool> DeleteEmployee(Guid employeeId);
        /// <summary>
        /// Updates employee 
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <param name="employee">updated employee entity</param>
        /// <returns></returns>
        Task<bool> UpdateEmployee(Guid employeeId, Employee employee);
        /// <summary>
        /// Gets employees list by manager identifier
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesByManagerId(Guid managerId);
        /// <summary>
        /// Gets employees list assigned to project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployeesForProject(Guid projectId);
    }
    /// <summary>
    /// Implementation of IEmployeesReoisutiry
    /// </summary>
    /// <seealso cref="IEmployeesRepository"/>
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeeContext dbContext;

        public EmployeesRepository(EmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Adds employee
        /// </summary>
        /// <param name="employee">employee entity</param>
        /// <returns></returns>
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            await this.dbContext.Employees.AddAsync(employee);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Deletes employee
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            Employee employee = this.dbContext.Employees.Find(employeeId);
            this.dbContext.Employees.Remove(employee);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Gets employee
        /// </summary>
        /// <param name="employeeId">employeee identifier</param>
        /// <returns></returns>
        public async Task<Employee> GetEmployee(Guid employeeId)
        {
            return await this.dbContext.Employees.Include(x => x.Projects).Include(x => x.JobHistories).ThenInclude(j => j.Position).FirstOrDefaultAsync(x => x.Id  == employeeId);
        }
        /// <summary>
        /// Gets employees list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.dbContext.Employees.Include(x => x.JobHistories).ThenInclude(j => j.Position).Include(x => x.Manager).ToListAsync();
        }
        /// <summary>
        /// Updates employee 
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <param name="employee">updated employee entity</param>
        /// <returns></returns>
        public async Task<bool> UpdateEmployee(Guid employeeId, Employee employeeModel)
        {
            var employee =  await this.dbContext.Employees.Include(x => x.JobHistories).Where(x => x.Id == employeeId).FirstOrDefaultAsync();
            employee.Update(employeeModel);
            this.dbContext.Employees.Update(employee);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Gets employees list by manager identifier
        /// </summary>
        /// <param name="managerId">manager identifier</param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesByManagerId(Guid managerId)
        {
            return await this.dbContext.Employees.Where(x => x.Manager.Id.Equals(managerId)).ToListAsync();
        }
        /// <summary>
        /// Gets employees satisfying criteria
        /// </summary>
        /// <param name="employeeCriteria">filtering criteria</param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployees(EmployeeCriteria employeeCriteria)
        {
            var specifiCationBuilder = new EmployeeExpressionBuilder(employeeCriteria)
                .AddFirstNameSpecification()
                .AddLastNameSpecification()
                .AddBirtDateSpecification();
            //.AddProjectSpecification()
            //.AddPositionSpecification();                       

            var employees = this.dbContext.Employees.Include(x => x.JobHistories)
                .ThenInclude(j => j.Position).Include(x => x.Manager).ThenInclude(m => m.Employee).Where(specifiCationBuilder.GetExpression());
            employees = AddExpresionsnWithSubexpressions(employees, employeeCriteria);
            return await employees.ToListAsync();
        }

        /// <summary>
        /// Gets employees list assigned to project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesForProject(Guid projectId)
        {
            return await this.dbContext.Employees.Include(e => e.Projects).ThenInclude(p => p.Project)
                .Include(x => x.JobHistories).ThenInclude(j => j.Position)
                .Include(x => x.Manager).ThenInclude(m => m.Employee)
                .Where(e => e.Projects.Select(p => p.ProjectId).Contains(projectId)).ToListAsync();
        }

        /// <summary>
        /// Creates filtered employees by criteria with subexpressions 
        /// </summary>
        /// <param name="employees">Employees filtered by specification pattern</param>
        /// <param name="employeeCriteria">filtering criteria</param>
        /// <returns></returns>
        private IQueryable<Employee> AddExpresionsnWithSubexpressions(IQueryable<Employee> employees, EmployeeCriteria employeeCriteria)
        {
            if (employeeCriteria.ProjectId.HasValue)
            {
                Expression<Func<Employee, bool>> projectExpression = e => e.Projects.Any(p => p.ProjectId == employeeCriteria.ProjectId.Value);
                employees = employees.Where(projectExpression);
            }

            if (employeeCriteria.PositionId.HasValue)
            {
                Expression<Func<Employee, bool>> positionExpression = e => e.JobHistories.Any(jh => jh.EndDate.HasValue == false && jh.PositionId == employeeCriteria.PositionId.Value);
                employees = employees.Where(positionExpression);
            }
            return employees;
        }
    }
}
