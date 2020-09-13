using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for deleting position <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class DeletePositionCommand : CommandBase<bool>
    {
        /// <summary>
        /// Position identifier
        /// </summary>
        public new Guid Id { get; set; }
        /// <summary>
        /// Creates instance of class <see cref="DeletePositionCommand"/>
        /// </summary>
        /// <param name="id">position identifier</param>
        public DeletePositionCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
