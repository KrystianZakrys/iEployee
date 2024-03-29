﻿using System;
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
        /// <summary>
        /// Updates employee data
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        /// <param name="sex"></param>
        /// <param name="address"></param>
        public void Update(string firstName, string lastName, DateTime birthDate, SexEnum sex, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Sex = sex;
            Address = address;
        }

        public void AssignEmployeeProject(Project project)
        {
            var employeeProject = EmployeeProject.Create(this, project);
            Projects.Add(employeeProject);
        }

        public void UnassignEmployeeProject(Project project)
        {
            var employeeProject = Projects.FirstOrDefault(x => x.ProjectId == project.Id);
            Projects.Remove(employeeProject);
        }
        public void ChangePosition(Position position, DateTime startDate, Decimal salary, DateTime? endDate = null)
        {

            var jobHistoryEntry = JobHistory.Create(startDate, salary, this, position, endDate);
            if (JobHistories != null)
            {
                JobHistories.Where(x => x.EndDate.HasValue == false).ToList().ForEach(x => x.AddEndDate(DateTime.Now));
            }
            else
            {
                JobHistories = new List<JobHistory>();
            }
               
            JobHistories.Add(jobHistoryEntry);
        }
    }
}
