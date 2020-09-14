using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using iEmployee.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command updates employee entity
    /// </summary>
    public class UpdateEmployeeCommand : CommandBase<bool>
    {
        public Guid EmployeeId { get; set; }
        public String FirstName { get; }
        public String LastName { get; }
        public AddressDTO Address { get; }
        public DateTime BirthDate { get; }
        public SexEnum Sex { get; }

        public UpdateEmployeeCommand(Guid id, EmployeeDTO employee)
        {
            EmployeeId = id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Address = employee.Address;
            BirthDate = employee.BirthDate;
            int.TryParse(employee.Sex, out int sex);
            Sex = (SexEnum)sex;
        }
    }
}
