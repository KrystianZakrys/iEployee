using iEmployee.Domain;
using iEmployee.Infrastructure.Command;
using iEmployee.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class AddProjectCommand : CommandBase<bool>
    {
        public String Name { get; set; }
        public AddProjectCommand(ProjectSaveModel project)
        {
            this.Name = project.Name;
        }
    }
}
