using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts
{
    /// <summary>
    /// Project entity data transfer object
    /// </summary>
    public class ProjectDTO
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
