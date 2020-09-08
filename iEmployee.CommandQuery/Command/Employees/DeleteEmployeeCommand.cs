
using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class DeleteEmployeeCommand : CommandBase<bool>
    {
        public new Guid Id { get; set; }
        public DeleteEmployeeCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
