using iEmployee.Contracts.Models;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for manager implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class GetManagerQuery : IQuery<ManagerDTO>
    {
        /// <summary>
        /// Manager identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
