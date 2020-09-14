using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Employees
{
    /// <summary>
    /// Command unassigning user from project <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class UnassignFromProjectCommand : CommandBase<bool>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Project identifier to be unassigned from
        /// </summary>
        public Guid ProjectId { get; set; } 
        /// <summary>
        /// Creates instance of class
        /// </summary>
        /// <param name="employeeId">employee identifier</param>
        /// <param name="projectId">project identifier</param>
        public UnassignFromProjectCommand(Guid employeeId, Guid projectId)
        {
            EmployeeId = employeeId;
            ProjectId = projectId;
        }    
    }
}
