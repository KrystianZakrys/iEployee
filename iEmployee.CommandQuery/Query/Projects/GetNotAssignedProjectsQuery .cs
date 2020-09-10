using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetNotAssignedProjectQuery : IQuery<ICollection<ProjectSaveModel>>
    {
        public Guid EmployeeId { get; set; }
    }
}
