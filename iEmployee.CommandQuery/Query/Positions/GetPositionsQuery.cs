using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for projects implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetPositionsQuery : IQuery<IEnumerable<PositionDTO>>
    {
    }
}
