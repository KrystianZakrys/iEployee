using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    public class GetPositionsQuery : IQuery<IEnumerable<PositionSaveModel>>
    {
    }
}
