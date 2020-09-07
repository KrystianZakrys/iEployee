using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain.Employees;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace iEmployee.CommandQuery.Query.Employees.GetEmployee
{
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, Employee>
    {
        private readonly iEmployeeContext db;

        public GetEmployeeQueryHandler(iEmployeeContext db)
        {
            this.db = db;
        }

        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await this.db.Employees.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
