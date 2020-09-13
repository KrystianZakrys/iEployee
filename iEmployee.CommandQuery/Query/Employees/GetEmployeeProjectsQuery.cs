using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for getting employee's projects implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetEmployeeProjectsQuery : IQuery<ICollection<ProjectDTO>>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid EmployeeId { get; set; }
    }
}
