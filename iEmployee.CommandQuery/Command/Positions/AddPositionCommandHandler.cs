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
    /// Command handler for <see cref="AddPositionCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class AddPositionCommandHandler : ICommandHandler<AddPositionCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddPositionCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="AddPositionCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(AddPositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var position = Position.Create(request.Name, request.Code);
                var result = await unitOfWork.PositionsRepository.AddPositionAsync(position);
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
