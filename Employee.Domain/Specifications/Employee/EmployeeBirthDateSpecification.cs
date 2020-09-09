using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public class EmployeeBirthDateSpecification : Specification<Employee>
    {
        private DateTime minDate { get; set; }
        private DateTime maxDate { get; set; }

        public EmployeeBirthDateSpecification(DateTime minDate, DateTime maxDate)
        {
            this.minDate = minDate;
            this.maxDate = maxDate;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => e.BirthDate >= minDate && e.BirthDate <= maxDate;
        }
    }
}
