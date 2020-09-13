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
    /// <summary>
    /// Command handler for <see cref="AddProjectCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class AddProjectCommandHandler : ICommandHandler<AddProjectCommand, bool>
    {
        private readonly IProjectsRepository projectsRepository;
        public AddProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="AddProjectCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = Project.Create(request.Name);
            return await this.projectsRepository.AddProjectAsync(project);
        }
    }
}
