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
        private readonly IPositionsRepository positionsRepository;
        public UpdatePositionCommandHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
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
            var position = Position.Create(request.Name,request.Code);
            return await this.positionsRepository.UpdatePosition(request.PositionId, position);
        }
    }
}
