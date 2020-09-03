using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Domain
{
    public class JobHistory : BaseEntity
    {
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public Decimal Salary { get; protected set; }

        public virtual Employee Employee { get; protected set; }
        public virtual Position Position { get; protected set; }
    }
}
