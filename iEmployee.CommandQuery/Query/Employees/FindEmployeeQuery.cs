using iEmployee.Contracts;
using iEmployee.Contracts.Criteria;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query for employee search implementing <seealso cref="IQuery{TResult}"/>
    /// </summary>
    public class FindEmployeeQuery : IQuery<IEnumerable<EmployeeDTO>>
    {
        /// <summary>
        /// Employee filtering criteria <see cref="EmployeeCriteria"/>
        /// </summary>
        public EmployeeCriteria employeeCriteria { get; set; }
        public FindEmployeeQuery(EmployeeCriteria employeeCriteria)
        {
            this.employeeCriteria = employeeCriteria;
        }
    }
}
