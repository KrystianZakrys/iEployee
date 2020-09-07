using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class UpdateEmployeeCommand : CommandBase<Employee>
    {
        public String FirstName { get; }
        public String LastName { get; }
        public AddressSaveModel Address { get; }
        public DateTime BirthDate { get; }
        public SexEnum Sex { get; }

        public UpdateEmployeeCommand(EmployeeSaveModel employee)
        {
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Address = employee.Address;
            this.BirthDate = employee.BirthDate;
            Int32.TryParse(employee.Sex, out int sex);
            this.Sex = (SexEnum)sex;
        }
    }
}
