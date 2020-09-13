using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Contracts;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Query;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for employee implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetEmployeeQuery : IQuery<EmployeeDTO>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
