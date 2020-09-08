using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Projects
{
    public class UpdateProjectCommand : CommandBase<bool>
    {
        public Guid ProjectId { get; set; }
        public String Name { get; }

        public UpdateProjectCommand(Guid id, ProjectSaveModel project)
        {
            this.ProjectId = id;
            this.Name = project.Name;
        }
    }
}
