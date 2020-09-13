using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for not actual position for employee implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetNotAssignedPositionsQuery : IQuery<ICollection<PositionDTO>>
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public Guid EmployeeId { get; set; }
    }
}
