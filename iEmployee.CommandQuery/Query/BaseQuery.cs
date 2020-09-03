using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Base class for query
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TCriteria">The type of the criteria.</typeparam>
    public abstract class BaseQuery<TResult, TCriteria>
    {
        protected readonly iEmployeeContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQuery{TResult, TCriteria}"/> class.
        /// </summary>
        /// <param name="context">The bask context.</param>
        protected BaseQuery(iEmployeeContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Executes the query filtered by specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public abstract Task<TResult> Execute(TCriteria criteria);
    }
}
