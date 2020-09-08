using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    public class GetManagersQuery : IQuery<IEnumerable<ManagerSaveModel>>
    {
    }
}
