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

        public static Manager Create(int RoomNumber, Employee employee, List<Employee> subordinates)
        {
            return new Manager()
            {
                RoomNumber = RoomNumber,
                Employee = employee,
                Suboridnates = subordinates
            };
        }
        public void Update(Manager manager)
        {
            this.Employee = manager.Employee;
            this.RoomNumber = manager.RoomNumber;
            this.Suboridnates = manager.Suboridnates;
        }

        public void ClearSubordinates()
        {
            this.Suboridnates.Clear();
        }
    }
}
