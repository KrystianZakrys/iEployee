using iEmployee.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectsQuery : IQuery<IEnumerable<Project>>
    {
    }
}
