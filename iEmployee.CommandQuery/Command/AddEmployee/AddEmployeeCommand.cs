using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Command;
using iEmployee.Domain.Employees;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iEmployee.Domain;
namespace iEmployee.CommandQuery.Command
{
    public class AddEmployeeCommand : CommandBase<Employee>
    {
        public String FirstName { get; }
        public String LastName { get; }
        public Address Address { get; }
        public DateTime BirthDate { get; }
        public SexEnum Sex { get; }

        public AddEmployeeCommand(EmployeeSaveModel employee)
        {
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Address = employee.Address;
            this.BirthDate = employee.BirthDate;
            Int32.TryParse(employee.Sex, out int sex);
            this.Sex = (SexEnum)sex;
        }
        public AddEmployeeCommand(String firstName, String lastName, Address address, DateTime birthDate, SexEnum sex)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.BirthDate = birthDate;
            this.Sex = sex;
        }
    }
}
