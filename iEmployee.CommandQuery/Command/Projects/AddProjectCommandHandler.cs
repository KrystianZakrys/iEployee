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
        private readonly IUnitOfWork unitOfWork;
        public AddProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            try
            {
                var project = Project.Create(request.Name);
                var result = await unitOfWork.ProjectsRepository.AddProjectAsync(project);
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
