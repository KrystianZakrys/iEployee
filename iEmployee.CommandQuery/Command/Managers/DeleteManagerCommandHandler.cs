using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class DeleteManagerCommandHandler : ICommandHandler<DeleteManagerCommand, bool>
    {
        public IManagersRepository managersRepository;
        public DeleteManagerCommandHandler(IManagersRepository managersRepository)
        {
            this.managersRepository = managersRepository;
        }
        public async Task<bool> Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            return await this.managersRepository.DeleteManager(request.Id);
        }
    }
}
