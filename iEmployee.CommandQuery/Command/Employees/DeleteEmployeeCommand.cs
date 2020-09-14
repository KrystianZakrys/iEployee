
using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command to delete employee <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class DeleteEmployeeCommand : CommandBase<bool>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public new Guid Id { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">employee identifier</param>
        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}
