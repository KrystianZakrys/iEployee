using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Employees
{
    public class ChangeEmployeePositionCommand : CommandBase<bool>
    {
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Decimal Salary { get; set; }

        public ChangeEmployeePositionCommand(Guid employeeId, Guid positionId, DateTime startDate, Decimal salary, DateTime? endDate = null)
        {
            this.EmployeeId = employeeId;
            this.PositionId = positionId;
            this.StartDate = startDate;
            this.Salary = salary;
            this.EndDate = endDate;
        }

        public ChangeEmployeePositionCommand(Guid employeeId, JobHistorySaveModel jobHistorySaveModel)
        {
            this.EmployeeId = employeeId;
            this.PositionId = jobHistorySaveModel.PositionId;
            this.StartDate = jobHistorySaveModel.StartDate;
            this.Salary = jobHistorySaveModel.Salary;
            this.EndDate = jobHistorySaveModel.EndDate;
        }
    }
}
