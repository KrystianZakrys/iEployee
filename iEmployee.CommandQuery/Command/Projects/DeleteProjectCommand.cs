using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command.Projects
{
    public class DeleteProjectCommand : CommandBase<bool>
    {
        public new Guid Id { get; set; }
        public DeleteProjectCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
