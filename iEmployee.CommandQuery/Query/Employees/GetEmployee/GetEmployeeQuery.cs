using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Query;

namespace iEmployee.CommandQuery.Query.Employees.GetEmployee
{
    public class GetEmployeeQuery : IQuery<Employee>
    {
        public Guid Id { get; set; }
    }
}
