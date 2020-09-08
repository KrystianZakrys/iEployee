using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Employees
{
    public class AssignToProjectCommand : CommandBase<bool>
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; } 
        public AssignToProjectCommand(Guid employeeId, Guid projectId)
        {
            this.EmployeeId = employeeId;
            this.ProjectId = projectId;
        }    
    }
}
