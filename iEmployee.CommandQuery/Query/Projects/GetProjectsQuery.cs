
using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;
using iEmployee.Contracts;

namespace iEmployee.CommandQuery.Query.Projects
{
    /// <summary>
    /// Query for projects implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetProjectsQuery : IQuery<IEnumerable<ProjectDTO>>
    {
    }
}
