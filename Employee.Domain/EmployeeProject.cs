using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace iEmployee.Domain
{
    public class EmployeeProject: BaseEntity
    {
        public Employee Employee { get; protected set; }
        public Project Project { get; protected set; }

        public static EmployeeProject Create(Employee employee, Project project)
        {
            return new EmployeeProject() { Employee = employee, Project = project};
        }
    }
}
