using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class DeletePositionCommand : CommandBase<bool>
    {
        public new Guid Id { get; set; }
        public DeletePositionCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
