using iEmployee.Domain;
using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.AddProject
{
    public class AddProjectCommand : CommandBase<Project>
    {
        public String Name { get; set; }
        public AddProjectCommand(ProjectSaveModel project)
        {
            this.Name = project.Name;
        }
    }
}
