using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Projects
{
    /// <summary>
    /// Command for deleting project <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class DeleteProjectCommand : CommandBase<bool>
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        public new Guid Id { get; set; }
        /// <summary>
        /// Creates instance of class <see cref="DeleteProjectCommand"/>
        /// </summary>
        /// <param name="id">project identifier</param>
        public DeleteProjectCommand(Guid id)
        {
            Id = id;
        }
    }
}
