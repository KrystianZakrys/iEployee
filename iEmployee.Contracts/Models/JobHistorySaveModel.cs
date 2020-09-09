using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Contracts.Models
{
    public class JobHistorySaveModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Decimal Salary { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }

    }
}
