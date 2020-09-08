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
    public class AddPositionCommandHandler : ICommandHandler<AddPositionCommand, bool>
    {
        private readonly IPositionsRepository positionsRepository;
        public AddPositionCommandHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }
        public async Task<bool> Handle(AddPositionCommand request, CancellationToken cancellationToken)
        {
            var position = Position.Create(request.Name,request.Code);
            return await this.positionsRepository.AddPositionAsync(position);
        }
    }
}
