using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    class EmployeePositionSpecification : Specification<Employee>
    {
        private readonly Guid positionId;

        public EmployeePositionSpecification(Guid positionId)
        {
            this.positionId = positionId;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => e.JobHistories.Where(x => x.EndDate == null).Select(x => x.PositionId).Contains(positionId);
        }
    }
}
