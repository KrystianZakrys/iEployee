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
        void AddEmployeeAsync(Employee employee);
        void DeleteEmployee(Guid employeeId);
        void UpdateStudent(Guid employeeId, Employee employee);        

    }
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly iEmployeeContext dbContext;

        public EmployeesRepository(iEmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddEmployeeAsync(Employee employee)
        {

            this.dbContext.Employees.AddAsync(employee);
        }

        public void DeleteEmployee(Guid employeeId)
        {
            Employee employee = this.dbContext.Employees.Find(employeeId);
            this.dbContext.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployee(Guid employeeId)
        {
            return await this.dbContext.Employees.FindAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.dbContext.Employees.ToListAsync();
        }

        public void UpdateStudent(Guid employeeId, Employee employeeModel)
        {
            var employee = this.dbContext.Employees.Find(employeeId);
            employee = employeeModel;            
            dbContext.SaveChanges();
        }
    }
}
