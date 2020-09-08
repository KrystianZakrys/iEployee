using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Contracts;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Query;

namespace iEmployee.CommandQuery.Query
{
    public class GetEmployeeQuery : IQuery<EmployeeSaveModel>
    {
        public Guid Id { get; set; }
    }
}
