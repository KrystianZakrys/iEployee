using iEmployee.Contracts.Criteria;
using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public class EmployeeSpecificationBuilder
    {
        private readonly List<Specification<Employee>> employeeSpecifications;
        private readonly EmployeeCriteria employeeCriteria;

        public EmployeeSpecificationBuilder(EmployeeCriteria employeeCriteria)
        {
            this.employeeCriteria = employeeCriteria;
            this.employeeSpecifications = new List<Specification<Employee>>();
        }
        public  Expression<Func<Employee,bool>> GetExpression()
        {
            Expression<Func<Employee, bool>> result = x => true;
            if (this.employeeSpecifications.Count <= 0) return result;
            Specification<Employee> startSpecification = this.employeeSpecifications?.FirstOrDefault();
            this.employeeSpecifications.Remove(startSpecification);
            this.employeeSpecifications.ForEach(x => {
                startSpecification = startSpecification.And(x);
            });
            result = startSpecification.ToExpression();
            return result;
        }

        public EmployeeSpecificationBuilder AddFirstNameSpecification()
        {
            if (!String.IsNullOrEmpty(this.employeeCriteria.FirstName))
            {
                var specification = new EmployeeFirstNameSpecification(this.employeeCriteria.FirstName);
                this.employeeSpecifications.Add(specification);                
            }
            return this;
        }
        public EmployeeSpecificationBuilder AddLastNameSpecification()
        {
            if (!String.IsNullOrEmpty(this.employeeCriteria.LastName))
            {
                var specification = new EmployeeLastNameSpecification(this.employeeCriteria.LastName);
                this.employeeSpecifications.Add(specification);
            } 
            return this;
        }

        public EmployeeSpecificationBuilder AddBirtDateSpecification()
        {
            if (this.employeeCriteria.MaxBirthDate.HasValue && this.employeeCriteria.MinBirthDate.HasValue)
            {
                var specification = new EmployeeBirthDateSpecification(this.employeeCriteria.MinBirthDate.Value, this.employeeCriteria.MaxBirthDate.Value);
                this.employeeSpecifications.Add(specification);
            }
            return this;
        }
        public EmployeeSpecificationBuilder AddProjectSpecification()
        {
            if (employeeCriteria.ProjectId.HasValue)
            {
                var specification = new EmployeeProjectSpecification(employeeCriteria.ProjectId.Value);
                this.employeeSpecifications.Add(specification);
            }
            return this;
        }

        public EmployeeSpecificationBuilder AddPositionSpecification()
        {
            if (employeeCriteria.PositionId.HasValue)
            {
                var specification = new EmployeePositionSpecification(employeeCriteria.PositionId.Value);
                var exp = specification.ToExpression();
                this.employeeSpecifications.Add(specification);
            }
            return this;
        }
    }
}
