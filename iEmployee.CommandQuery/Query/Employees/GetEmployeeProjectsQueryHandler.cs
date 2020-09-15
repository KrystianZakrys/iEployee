using iEmployee.CommandQuery.Query.Projects;
using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query handler for <see cref="GetEmployeeProjectsQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetEmployeeProjectsQueryHandler : IQueryHandler<GetEmployeeProjectsQuery, ICollection<ProjectDTO>>
    {
        private readonly IProjectsRepository projectsRepository;
        public GetEmployeeProjectsQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetEmployeeProjectsQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>project DTO list</returns>
        public async Task<ICollection<ProjectDTO>> Handle(GetEmployeeProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await projectsRepository.GetEmployeeProjects(request.EmployeeId);
            var projectSaveModels = new List<ProjectDTO>();
            projects.ToList().ForEach(p => {
                projectSaveModels.Add(new ProjectDTO()
                {
                    Id = p.Id,
                    Name = p.Name
                });
            });
            return projectSaveModels;
        }
    }
}
