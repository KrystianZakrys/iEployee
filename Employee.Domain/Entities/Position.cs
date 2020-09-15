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
        
        public ICollection<JobHistory> JobHistories { get; protected set; }

        public static Position Create(string name, string code)
        {
            return new Position() { Name = name, Code = code };
        }
        public void Update(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
