using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace iEmployee.Domain
{
    public class Position : BaseEntity
    {
        public String Code { get; protected set; }
        public String Name { get; protected set; }        
    }
}
