﻿using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using iEmployee.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Command
{
    public class UpdateEmployeeCommand : CommandBase<bool>
    {
        public Guid EmployeeId { get; set; }
        public String FirstName { get; }
        public String LastName { get; }
        public AddressSaveModel Address { get; }
        public DateTime BirthDate { get; }
        public SexEnum Sex { get; }

        public UpdateEmployeeCommand(Guid id, EmployeeSaveModel employee)
        {
            this.EmployeeId = id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Address = employee.Address;
            this.BirthDate = employee.BirthDate;
            Int32.TryParse(employee.Sex, out int sex);
            this.Sex = (SexEnum)sex;
        }
    }
}