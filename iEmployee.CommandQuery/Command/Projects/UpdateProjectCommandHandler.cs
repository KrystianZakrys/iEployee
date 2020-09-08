using iEmployee.Domain;
using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.Projects
{
    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand, bool>
    {
        private readonly IProjectsRepository projectsRepository;
        public UpdateProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = Project.Create(request.Name);
            return await this.projectsRepository.UpdateProject(request.ProjectId, project);
        }
    }
}
