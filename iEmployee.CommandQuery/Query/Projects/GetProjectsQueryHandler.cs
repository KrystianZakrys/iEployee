using System;
using System.Collections.Generic;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, IEnumerable<Project>>
    {
        private readonly iEmployeeContext db;

        public GetProjectsQueryHandler(iEmployeeContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return await db.Projects.ToListAsync();
        }
    }
}
