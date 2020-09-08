using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class DeletePositionCommandHandler : ICommandHandler<DeleteEmployeeCommand, bool>
    {
        public IPositionsRepository positionsRepository;
        public DeletePositionCommandHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await this.positionsRepository.DeletePosition(request.Id);
        }
    }
}
