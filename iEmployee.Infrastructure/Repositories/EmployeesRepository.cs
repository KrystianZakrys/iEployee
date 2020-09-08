using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iEmployee.CommandQuery;
using iEmployee.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace iEmployee.Infrastructure.Repositories
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid employeeId);
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployee(Guid employeeId);
        Task<bool> UpdateEmployee(Guid employeeId, Employee employee);        

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
            return await this.dbContext.Employees.FindAsync(employeeId);
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
    }
}
