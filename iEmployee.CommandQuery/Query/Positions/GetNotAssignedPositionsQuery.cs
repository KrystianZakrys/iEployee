using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    public class GetNotAssignedPositionsQuery : IQuery<ICollection<PositionSaveModel>>
    {
        public Guid EmployeeId { get; set; }
    }
}
