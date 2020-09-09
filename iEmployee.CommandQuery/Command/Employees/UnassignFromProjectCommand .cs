using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Employees
{
    public class UnassignFromProjectCommand : CommandBase<bool>
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; } 
        public UnassignFromProjectCommand(Guid employeeId, Guid projectId)
        {
            this.EmployeeId = employeeId;
            this.ProjectId = projectId;
        }    
    }
}
