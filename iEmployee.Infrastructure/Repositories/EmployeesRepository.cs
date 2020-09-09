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
            this.dbContext.SaveChangesAsync();
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
            return await this.dbContext.Employees.Include(x=> x.Projects).FirstOrDefaultAsync(x => x.Id  == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.dbContext.Employees.ToListAsync();
        }

        public async Task<bool> UpdateEmployee(Guid employeeId, Employee employeeModel)
        {
            var employee =  this.dbContext.Employees.Find(employeeId);
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
            var specifiCationBuilder = new EmployeeSpecificationBuilder(employeeCriteria)
                .AddFirstNameSpecification()
                .AddLastNameSpecification()
                .AddBirtDateSpecification()
                .AddProjectSpecification()
                .AddPositionSpecification();           
            
            return await this.dbContext.Employees.Where(specifiCationBuilder.GetExpression()).ToListAsync();
        }
    }
}