
using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;
using iEmployee.Contracts;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectsQuery : IQuery<IEnumerable<ProjectSaveModel>>
    {
    }
}
