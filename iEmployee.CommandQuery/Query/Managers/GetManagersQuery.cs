using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for managers implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetManagersQuery : IQuery<IEnumerable<ManagerDTO>>
    {
    }
}
