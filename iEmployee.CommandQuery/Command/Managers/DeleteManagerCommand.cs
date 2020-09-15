using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for deleting manager <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class DeleteManagerCommand : CommandBase<bool>
    {
        /// <summary>
        /// Manager identifier
        /// </summary>
        public new Guid Id { get; set; }
        /// <summary>
        /// Creating instance of class <see cref="DeleteManagerCommand"/>
        /// </summary>
        /// <param name="id">Manager identifier</param>
        public DeleteManagerCommand(Guid id)
        {
            Id = id;
        }
    }
}
