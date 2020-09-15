using iEmployee.Contracts.Criteria;
using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public class EmployeeExpressionBuilder
    {
        private readonly List<Specification<Employee>> employeeSpecifications;
        private readonly EmployeeCriteria employeeCriteria;

        public EmployeeExpressionBuilder(EmployeeCriteria employeeCriteria)
        {
            this.employeeCriteria = employeeCriteria;
            employeeSpecifications = new List<Specification<Employee>>();
        }
        public  Expression<Func<Employee,bool>> GetExpression()
        {
            Expression<Func<Employee, bool>> result = x => true;
            if (employeeSpecifications.Count <= 0) return result;
            Specification<Employee> startSpecification = employeeSpecifications?.FirstOrDefault();
            employeeSpecifications.Remove(startSpecification);
            employeeSpecifications.ForEach(x => {
                startSpecification = startSpecification.And(x);
            });
            result = startSpecification.ToExpression();            
            return result;
        }

        public EmployeeExpressionBuilder AddFirstNameSpecification()
        {
            if (!String.IsNullOrEmpty(employeeCriteria.FirstName))
            {
                var specification = new EmployeeFirstNameSpecification(employeeCriteria.FirstName);
                employeeSpecifications.Add(specification);                
            }
            return this;
        }
        public EmployeeExpressionBuilder AddLastNameSpecification()
        {
            if (!String.IsNullOrEmpty(employeeCriteria.LastName))
            {
                var specification = new EmployeeLastNameSpecification(employeeCriteria.LastName);
                employeeSpecifications.Add(specification);
            } 
            return this;
        }

        public EmployeeExpressionBuilder AddBirtDateSpecification()
        {
            if (employeeCriteria.MaxBirthDate.HasValue && employeeCriteria.MinBirthDate.HasValue)
            {
                var specification = new EmployeeBirthDateSpecification(employeeCriteria.MinBirthDate.Value, employeeCriteria.MaxBirthDate.Value);
                employeeSpecifications.Add(specification);
            }
            return this;
        }
        public EmployeeExpressionBuilder AddProjectSpecification()
        {
            if (employeeCriteria.ProjectId.HasValue)
            {
                var specification = new EmployeeProjectSpecification(employeeCriteria.ProjectId.Value);
                employeeSpecifications.Add(specification);
            }
            return this;
        }

        public EmployeeExpressionBuilder AddPositionSpecification()
        {
            if (employeeCriteria.PositionId.HasValue)
            {
                var specification = new EmployeePositionSpecification(employeeCriteria.PositionId.Value);
                var exp = specification.ToExpression();
                employeeSpecifications.Add(specification);
            }
            return this;
        }
    }
}
