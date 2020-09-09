using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Domain
{
    public class EmployeeProject : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public static EmployeeProject Create(Employee employee, Project project)
        {
            return new EmployeeProject() { Employee = employee, EmployeeId = employee.Id, Project = project, ProjectId = project.Id };
        }
    }
}
