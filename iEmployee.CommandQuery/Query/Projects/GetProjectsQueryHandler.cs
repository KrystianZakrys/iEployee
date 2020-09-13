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
    /// <summary>
    /// Query handler for <see cref="GetProjectsQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, IEnumerable<ProjectDTO>>
    {
        private readonly IProjectsRepository projectsRepository;

        public GetProjectsQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetProjectEmployeesQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>project DTO list</returns>
        public async Task<IEnumerable<ProjectDTO>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await projectsRepository.GetProjects();
            var projectsModels = projects.Select(x => new ProjectDTO()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            );
            return projectsModels;
        }
    }
}
