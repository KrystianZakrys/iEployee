using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace iEmployee.Domain.Employees
{
    public class Employee : BaseEntity
    {
        public String FirstName { get; protected set; }
        public String LastName { get; protected set; }
        public SexEnum Sex { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Address Address { get; protected set; }
        public Manager Manager { get; protected set; }
        public ICollection<EmployeeProject> Projects { get; protected set;}
    }
}
