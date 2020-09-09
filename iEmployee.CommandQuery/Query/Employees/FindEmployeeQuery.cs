using iEmployee.Contracts;
using iEmployee.Contracts.Criteria;
using iEmployee.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.CommandQuery.Query
{
    public class FindEmployeeQuery : IQuery<IEnumerable<EmployeeSaveModel>>
    {
        public EmployeeCriteria employeeCriteria { get; set; }
        public FindEmployeeQuery(EmployeeCriteria employeeCriteria)
        {
            this.employeeCriteria = employeeCriteria;
        }
    }
}
