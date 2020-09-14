using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Employees
{
    /// <summary>
    /// Command assigning employee to project <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class AssignToProjectCommand : CommandBase<bool>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Project identifier
        /// </summary>
        public Guid ProjectId { get; set; }
        /// <summary>
        /// Creates instance of class
        /// </summary>
        /// <param name="employeeId">Employee identifier</param>
        /// <param name="projectId">Project identifier</param>
        public AssignToProjectCommand(Guid employeeId, Guid projectId)
        {
            EmployeeId = employeeId;
            ProjectId = projectId;
        }    
    }
}
