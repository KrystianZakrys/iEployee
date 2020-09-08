using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using iEmployee.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectSaveModel>
    {
        private readonly IProjectsRepository projectsRepository;
        public GetProjectQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task<ProjectSaveModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await this.projectsRepository.GetProject(request.Id);
            return new ProjectSaveModel() { Id = project.Id, Name = project.Name };
        }


    }
}
