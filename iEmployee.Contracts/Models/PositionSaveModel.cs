using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace iEmployee.Contracts
{
    public class PositionSaveModel
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
    }
}
