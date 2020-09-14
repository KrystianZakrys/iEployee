using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Command;
using iEmployee.Contracts;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iEmployee.Domain;
using Microsoft.IdentityModel.JsonWebTokens;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for adding employee <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class AddEmployeeCommand : CommandBase<bool>
    {
        /// <summary>
        /// Employee first name
        /// </summary>
        public String FirstName { get; }
        /// <summary>
        /// Employee last name
        /// </summary>
        public String LastName { get; }
        /// <summary>
        /// Adress data transfer object <see cref="AddressDTO"/>
        /// </summary>
        public AddressDTO Address { get; }
        /// <summary>
        /// Employee birth date
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Employee gender
        /// </summary>
        public SexEnum Sex { get; }

        /// <summary>
        /// Creates instance of class from EmployeDTO <see cref="EmployeeDTO"/>
        /// </summary>
        /// <param name="employee">Employee data transfer object </param>
        public AddEmployeeCommand(EmployeeDTO employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Address = employee.Address;
            BirthDate = employee.BirthDate;
            Int32.TryParse(employee.Sex, out int sex);
            Sex = (SexEnum)sex;
        }
    }
}
