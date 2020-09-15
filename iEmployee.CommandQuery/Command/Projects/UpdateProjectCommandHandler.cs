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
        private readonly IUnitOfWork unitOfWork;
        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            try
            {
                var project = await unitOfWork.ProjectsRepository.GetProject(request.ProjectId);
                project.Update(request.Name);
                var result = await unitOfWork.ProjectsRepository.UpdateProject(project);
                unitOfWork.Commit();
                return result;
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
                return false;
            }
          
        }
    }
}
