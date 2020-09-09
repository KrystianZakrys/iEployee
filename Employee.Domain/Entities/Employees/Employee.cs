using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using iEmployee.Contracts;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
        public ICollection<JobHistory> JobHistories { get; protected set; } 
        public Employee() { }

        public static Employee Create(string firstName, string lastName, SexEnum sex, DateTime birthDate, Address address)
        {
            Employee employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Sex = sex,
                BirthDate = birthDate,
                Address = address
            };            
            return employee;
        }

        public void Update(Employee employeeData)
        {
            this.FirstName = employeeData.FirstName;
            this.LastName = employeeData.LastName;
            this.BirthDate = employeeData.BirthDate;
            this.Sex = employeeData.Sex;
            this.Address = employeeData.Address;
            this.Manager = employeeData.Manager;
            this.Projects = employeeData.Projects;
            this.JobHistories = employeeData.JobHistories;
        }

        public void AssignEmployeeProject(Project project)
        {
            var employeeProject = EmployeeProject.Create(this, project);
            this.Projects.Add(employeeProject);
        }

        public void UnassignEmployeeProject(Project project)
        {
            var employeeProject = this.Projects.Where(x => x.ProjectId == project.Id).FirstOrDefault();
            this.Projects.Remove(employeeProject);
        }
        public void ChangePosition(Position position, DateTime startDate, Decimal salary, DateTime? endDate = null)
        {

            var jobHistoryEntry = JobHistory.Create(startDate, salary, this, position, endDate);
            if (this.JobHistories != null)
            {
                this.JobHistories.Where(x => x.EndDate.HasValue == false).ToList().ForEach(x => x.AddEndDate(DateTime.Now));
            }
            else
            {
                this.JobHistories = new List<JobHistory>();
            }
               
            this.JobHistories.Add(jobHistoryEntry);
        }
    }
}
