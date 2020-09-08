using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class DeleteManagerCommand : CommandBase<bool>
    {
        public new Guid Id { get; set; }
        public DeleteManagerCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
