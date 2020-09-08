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
    public class UpdatePositionCommandHandler : ICommandHandler<UpdatePositionCommand, bool>
    {
        private readonly IPositionsRepository positionsRepository;
        public UpdatePositionCommandHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }
        public async Task<bool> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = Position.Create(request.Name,request.Code);
            return await this.positionsRepository.UpdatePosition(request.PositionId, position);
        }
    }
}
