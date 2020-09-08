using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain.Employees;
using iEmployee.Contracts;

namespace iEmployee.CommandQuery.Query
{
    public class GetEmployeesQuery : IQuery<IEnumerable<EmployeeSaveModel>>
    {
    }
}
