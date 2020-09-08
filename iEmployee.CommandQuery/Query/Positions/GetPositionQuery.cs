using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    public class GetPositionQuery : IQuery<PositionSaveModel>
    {
        public Guid Id { get; set; }
    }
}
