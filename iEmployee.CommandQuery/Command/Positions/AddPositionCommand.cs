using iEmployee.Contracts;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class AddPositionCommand : CommandBase<bool>
    {
        public String Name { get; set; }
        public String Code { get; set; }

        public AddPositionCommand(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }
        public AddPositionCommand(PositionSaveModel position)
        {
            this.Name = position.Name;
            this.Code = position.Code;
        }
    }
}
