using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace iEmployee.Contracts
{
    /// <summary>
    /// Position entity data transfer object
    /// </summary>
    public class PositionDTO
    {
        /// <summary>
        /// Position identifier
        /// </summary>
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
