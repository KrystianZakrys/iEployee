using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query.Projects
{
    /// <summary>
    /// Query for not assigned projects implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetNotAssignedProjectQuery : IQuery<ICollection<ProjectDTO>>
    {
        /// <summary>
        /// Identifier of employee to get assigned projects
        /// </summary>
        public Guid EmployeeId { get; set; }
    }
}
