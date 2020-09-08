using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class UpdatePositionCommand : CommandBase<bool>
    {
        public Guid PositionId { get; set; }
        public String Name { get; }
        public String Code { get; }

        public UpdatePositionCommand(Guid id, PositionSaveModel position)
        {
            this.PositionId = id;
            this.Name = position.Name;
            this.Code = position.Code;
        }
    }
}
