﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iEmployee.Domain.Employees
{
    public class Manager : BaseEntity
    {
        public int RoomNumber { get; protected set; }
        public Employee Employee { get; protected set; }

        public ICollection<Employee> Subordinates { get; protected set; }

        public static Manager Create(int RoomNumber, Employee employee, List<Employee> subordinates)
        {
            return new Manager()
            {
                RoomNumber = RoomNumber,
                Employee = employee,
                Subordinates = subordinates
            };
        }
        public void Update(int roomNumber, List<Employee> employees)
        {
            RoomNumber = roomNumber;
            Subordinates = employees;
        }

        public void ClearSubordinates()
        {
            Subordinates.Clear();
        }
    }
}
