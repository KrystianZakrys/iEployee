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
    /// <summary>
    /// Command handler for <see cref="UpdateProjectCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand, bool>
    {
        private readonly IProjectsRepository projectsRepository;
        public UpdateProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="UpdateProjectCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = Project.Create(request.Name);
            return await this.projectsRepository.UpdateProject(request.ProjectId, project);
        }
    }
}
