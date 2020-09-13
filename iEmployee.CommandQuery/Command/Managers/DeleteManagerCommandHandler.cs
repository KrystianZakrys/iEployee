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
    /// Command handler for <see cref="DeleteManagerCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class DeleteManagerCommandHandler : ICommandHandler<DeleteManagerCommand, bool>
    {
        public IManagersRepository managersRepository;
        public DeleteManagerCommandHandler(IManagersRepository managersRepository)
        {
            this.managersRepository = managersRepository;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="DeleteManagerCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            return await this.managersRepository.DeleteManager(request.Id);
        }
    }
}
