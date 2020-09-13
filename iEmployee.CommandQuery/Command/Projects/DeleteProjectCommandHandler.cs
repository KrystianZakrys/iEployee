using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.Projects
{
    /// <summary>
    /// Command handler for <see cref="DeleteProjectCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand, bool>
    {
        public IProjectsRepository projectsRepository;
        public DeleteProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="DeleteProjectCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            return await this.projectsRepository.DeleteProject(request.Id);
        }
    }
}
