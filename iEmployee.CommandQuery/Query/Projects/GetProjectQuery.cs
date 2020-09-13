using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query.Projects
{
    /// <summary>
    /// Query for project implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetProjectQuery : IQuery<ProjectDTO>
    {
        /// <summary>
        /// Project identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
