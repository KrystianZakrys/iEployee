using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.Projects
{
    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand, bool>
    {
        public IProjectsRepository projectsRepository;
        public DeleteProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            return await this.projectsRepository.DeleteProject(request.Id);
        }
    }
}
