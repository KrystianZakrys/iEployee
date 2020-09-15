using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public class EmployeeLastNameSpecification : Specification<Employee>
    {
        private readonly String lastName;

        public EmployeeLastNameSpecification(String lastName)
        {
            this.lastName = lastName;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => e.LastName == lastName;
        }
    }
}