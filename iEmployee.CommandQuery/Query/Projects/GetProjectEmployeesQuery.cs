using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain.Employees;
using iEmployee.Contracts;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for employees assigned to project <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetProjectEmployeesQuery : IQuery<IEnumerable<EmployeeDTO>>
    {
        /// <summary>
        /// Project identifier to get list of assigned employees
        /// </summary>
        public Guid ProjectId { get; set; }
    }
}
