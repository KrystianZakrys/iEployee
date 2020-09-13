using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Projects
{
    /// <summary>
    /// Command for deleting project <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class UpdateProjectCommand : CommandBase<bool>
    {
        public Guid ProjectId { get; set; }
        public String Name { get; }
        /// <summary>
        /// Creates instance of class <see cref="UpdateProjectCommand"/>
        /// </summary>
        /// <param name="id">project identifier</param>
        /// <param name="project">project data transfer object</param>
        public UpdateProjectCommand(Guid id, ProjectDTO project)
        {
            this.ProjectId = id;
            this.Name = project.Name;
        }
    }
}
