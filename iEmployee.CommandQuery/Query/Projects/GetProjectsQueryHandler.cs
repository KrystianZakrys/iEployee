using System;
using System.Collections.Generic;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using iEmployee.Contracts;
using iEmployee.Infrastructure.Repositories;

namespace iEmployee.CommandQuery.Query.Projects
{
    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, IEnumerable<ProjectSaveModel>>
    {
        private readonly IProjectsRepository projectsRepository;

        public GetProjectsQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task<IEnumerable<ProjectSaveModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await projectsRepository.GetProjects();
            var projectsModels = projects.Select(x => new ProjectSaveModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            );
            return projectsModels;
        }
    }
}
