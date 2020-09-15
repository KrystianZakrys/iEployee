using iEmployee.Domain;
using iEmployee.Infrastructure.Command;
using iEmployee.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for adding project <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class AddProjectCommand : CommandBase<bool>
    {
        public String Name { get; set; }
        public AddProjectCommand(ProjectDTO project)
        {
            Name = project.Name;
        }
    }
}
