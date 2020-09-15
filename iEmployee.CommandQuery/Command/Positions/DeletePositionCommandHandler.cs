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
    /// Command handler for <see cref="DeleteEmployeeCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class DeletePositionCommandHandler : ICommandHandler<DeleteEmployeeCommand, bool>
    {
        public IUnitOfWork unitOfWork;
        public DeletePositionCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="DeleteEmployeeCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await unitOfWork.PositionsRepository.DeletePosition(request.Id);
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
