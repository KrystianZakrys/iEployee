using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    /// <summary>
    /// Command for adding position <seealso cref="CommandBase{bool}"/>
    /// </summary>
    public class AddPositionCommand : CommandBase<bool>
    {
        public String Name { get; set; }
        public String Code { get; set; }
        public AddPositionCommand(PositionDTO position)
        {
            this.Name = position.Name;
            this.Code = position.Code;
        }
    }
}
