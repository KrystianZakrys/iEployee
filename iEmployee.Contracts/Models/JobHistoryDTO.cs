using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts.Models
{
    /// <summary>
    /// JobHistory entity data transfer object
    /// </summary>
    public class JobHistoryDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Decimal Salary { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }

    }
}
