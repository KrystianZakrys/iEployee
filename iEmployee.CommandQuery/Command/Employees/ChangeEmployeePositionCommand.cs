using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Employees
{
    /// <summary>
    /// Command changing employee's position <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class ChangeEmployeePositionCommand : CommandBase<bool>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Position identifier
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Start date of working at position
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of working at position
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Employee's salary at position
        /// </summary>
        public Decimal Salary { get; set; }
        /// <summary>
        /// Creates instance of class <seealso cref="JobHistoryDTO"/>
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <param name="jobHistorySaveModel">job history entry linking employee with position</param>
        public ChangeEmployeePositionCommand(Guid employeeId, JobHistoryDTO jobHistorySaveModel)
        {
            this.EmployeeId = employeeId;
            this.PositionId = jobHistorySaveModel.PositionId;
            this.StartDate = jobHistorySaveModel.StartDate;
            this.Salary = jobHistorySaveModel.Salary;
            this.EndDate = jobHistorySaveModel.EndDate;
        }
    }
}
