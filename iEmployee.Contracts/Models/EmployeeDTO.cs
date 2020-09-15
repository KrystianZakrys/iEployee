using iEmployee.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace iEmployee.Contracts
{
    /// <summary>
    /// Employee entity data transfer object
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDTO Address { get; set; }
        public String ManagerName { get; set; }
        public PositionDTO? Position { get; set; }
        public List<ProjectDTO>? Projects { get; set; }

    }
}
