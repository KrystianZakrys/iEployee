using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for position implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetPositionQuery : IQuery<PositionDTO>
    {
        /// <summary>
        /// Position identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
