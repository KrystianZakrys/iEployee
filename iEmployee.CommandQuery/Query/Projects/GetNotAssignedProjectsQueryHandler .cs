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
    /// Query handler for <see cref="GetNotAssignedPositionsQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetNotAssignedProjectQueryHandler : IQueryHandler<GetNotAssignedProjectQuery, ICollection<ProjectDTO>>
    {
        private readonly IProjectsRepository projectsRepository;
        public GetNotAssignedProjectQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetNotAssignedPositionsQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>project DTO list</returns>
        public async Task<ICollection<ProjectDTO>> Handle(GetNotAssignedProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = await projectsRepository.GetNotAssignedProjects(request.EmployeeId);
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
