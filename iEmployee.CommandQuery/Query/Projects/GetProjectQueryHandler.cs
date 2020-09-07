using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, Project>
    {
        private readonly iEmployeeContext db;
        public GetProjectQueryHandler(iEmployeeContext db)
        {
            this.db = db;
        }

        public async Task<Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            return await db.Projects.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }


    }
}
