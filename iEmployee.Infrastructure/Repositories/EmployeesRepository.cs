﻿using System;
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
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid employeeId);
        Task<IEnumerable<Employee>> GetEmployees(EmployeeCriteria employeeCriteria);
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployee(Guid employeeId);
        Task<bool> UpdateEmployee(Guid employeeId, Employee employee);
        Task<IEnumerable<Employee>> GetEmployeesByManagerId(Guid managerId);
        Task<IEnumerable<Employee>> GetEmployeesForProject(Guid projectId);
    }
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly iEmployeeContext dbContext;

        public EmployeesRepository(iEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            await this.dbContext.Employees.AddAsync(employee);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            Employee employee = this.dbContext.Employees.Find(employeeId);
            this.dbContext.Employees.Remove(employee);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> GetEmployee(Guid employeeId)
        {
            return await this.dbContext.Employees.Include(x => x.Projects).Include(x => x.JobHistories).ThenInclude(j => j.Position).FirstOrDefaultAsync(x => x.Id  == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.dbContext.Employees.Include(x => x.JobHistories).ThenInclude(j => j.Position).Include(x => x.Manager).ToListAsync();
        }

        public async Task<bool> UpdateEmployee(Guid employeeId, Employee employeeModel)
        {
            var employee =  await this.dbContext.Employees.Include(x => x.JobHistories).Where(x => x.Id == employeeId).FirstOrDefaultAsync();
            employee.Update(employeeModel);
            this.dbContext.Employees.Update(employee);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByManagerId(Guid managerId)
        {
            return await this.dbContext.Employees.Where(x => x.Manager.Id.Equals(managerId)).ToListAsync();
        }

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

        public async Task<IEnumerable<Employee>> GetEmployeesForProject(Guid projectId)
        {
            return await this.dbContext.Employees.Include(e => e.Projects).ThenInclude(p => p.Project)
                .Include(x => x.JobHistories).ThenInclude(j => j.Position)
                .Include(x => x.Manager)
                .Where(e => e.Projects.Select(p => p.ProjectId).Contains(projectId)).ToListAsync();
        }
    }
}
