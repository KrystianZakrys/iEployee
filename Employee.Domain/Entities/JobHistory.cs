using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Domain
{
    public class JobHistory : BaseEntity
    {
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public Decimal Salary { get; protected set; }

        public Guid EmployeeId { get; protected set; }
        public virtual Employee Employee { get; protected set; }
        public Guid PositionId { get; protected set; }
        public virtual Position Position { get; protected set; }


        public static JobHistory Create(DateTime startDate, Decimal salary, Employee employee, Position position,DateTime? endDate  = null)
        {
            return new JobHistory()
            {
                Employee = employee,
                EmployeeId = employee.Id,
                Position = position,
                PositionId = position.Id,
                StartDate = startDate,
                Salary = salary,
                EndDate = endDate
            };
        }

        public void AddEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }
    }
}
