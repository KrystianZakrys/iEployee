using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for updating position <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class UpdatePositionCommand : CommandBase<bool>
    {
        public Guid PositionId { get; set; }
        public String Name { get; }
        public String Code { get; }
        /// <summary>
        /// Creates instance of class <see cref="UpdatePositionCommand"/>
        /// </summary>
        /// <param name="id">position identifier</param>
        /// <param name="position">position data transfer object</param>
        public UpdatePositionCommand(Guid id, PositionDTO position)
        {
            PositionId = id;
            Name = position.Name;
            Code = position.Code;
        }
    }
}
