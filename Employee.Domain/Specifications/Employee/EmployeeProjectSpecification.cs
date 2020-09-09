using iEmployee.Domain.Employees;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public class EmployeeProjectSpecification : Specification<Employee>
    {
        private readonly Guid employeeProjectId;

        public EmployeeProjectSpecification(Guid employeeProjectId)
        {
            this.employeeProjectId = employeeProjectId;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => e.Projects.Select(y => y.ProjectId).Contains(employeeProjectId);
        }
    }
}
