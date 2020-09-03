using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iEmployee.Domain.Employees
{
    [Table("Managers")]
    public class Manager : BaseEntity
    {
        public int RoomNumber { get; protected set; }
        public Employee Employee { get; protected set; }

        public ICollection<Employee> Suboridnates { get; protected set; }
    }
}
