using iEmployee.Domain;
using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class AddProjectCommandHandler : ICommandHandler<AddProjectCommand, bool>
    {
        private readonly IProjectsRepository projectsRepository;
        public AddProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        public async Task<bool> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = Project.Create(request.Name);
            return await this.projectsRepository.AddProjectAsync(project);
        }
    }
}
