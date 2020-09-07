using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectQuery : IQuery<Project>
    {
        public Guid Id { get; set; }
    }
}
