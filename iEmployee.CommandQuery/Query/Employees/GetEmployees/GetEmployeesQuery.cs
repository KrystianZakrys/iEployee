using iEmployee.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;

namespace iEmployee.CommandQuery.Query.Employees
{
    public class GetEmployeesQuery : IQuery<IEnumerable<Employee>>
    {
    }
}
