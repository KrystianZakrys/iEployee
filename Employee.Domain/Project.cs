using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using iEmployee.Domain.Employees;

namespace iEmployee.Domain
{
    public class Project : BaseEntity
    {
        public String Name { get; protected set; }
        
        public ICollection<EmployeeProject> Employees { get; protected set; }

        public Project(String name)
        {
            this.Name = name;
        }
    }
}
