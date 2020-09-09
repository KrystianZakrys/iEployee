using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public class EmployeeFirstNameSpecification : Specification<Employee>
    {
        private readonly String firstName;

        public EmployeeFirstNameSpecification(String firstName)
        {
            this.firstName = firstName;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => e.FirstName == this.firstName;
        }
    }
}
