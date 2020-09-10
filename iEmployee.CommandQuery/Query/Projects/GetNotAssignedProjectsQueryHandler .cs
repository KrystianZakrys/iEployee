﻿using iEmployee.CommandQuery.Query.Projects;
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
    public class GetNotAssignedProjectQueryHandler : IQueryHandler<GetNotAssignedProjectQuery, ICollection<ProjectSaveModel>>
    {
        private readonly IProjectsRepository projectsRepository;
        public GetNotAssignedProjectQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task<ICollection<ProjectSaveModel>> Handle(GetNotAssignedProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = await this.projectsRepository.GetNotAssignedProjects(request.EmployeeId);
            var projectSaveModels = new List<ProjectSaveModel>();
            projects.ToList().ForEach(p => {
                projectSaveModels.Add(new ProjectSaveModel()
                {
                    Id = p.Id,
                    Name = p.Name
                });
            });
            return projectSaveModels;
        }
    }
}
