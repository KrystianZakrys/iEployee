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
    /// Command handler for <see cref="UpdatePositionCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class UpdatePositionCommandHandler : ICommandHandler<UpdatePositionCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdatePositionCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="UpdatePositionCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var position = await unitOfWork.PositionsRepository.GetPosition(request.PositionId);
                position.Update(request.Name, request.Code);
                var result = await unitOfWork.PositionsRepository.UpdatePosition(position);
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
