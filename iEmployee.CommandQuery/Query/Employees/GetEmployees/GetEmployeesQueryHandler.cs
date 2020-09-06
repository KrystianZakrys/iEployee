using System;
using System.Collections.Generic;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain.Employees;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iEmployee.CommandQuery.Query.Employees.GetEmployees
{
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, List<Employee>>
    {
        private readonly iEmployeeContext db;

        public GetEmployeesQueryHandler(iEmployeeContext db)
        {            
            this.db = db;
        }

        public async Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return db.Employees.ToList();
        }
    }
}
