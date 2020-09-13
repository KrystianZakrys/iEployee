using iEmployee.Contracts;
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
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, bool>
    {
        public IEmployeesRepository employeesRepository;
        public DeleteEmployeeCommandHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
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
           return await this.employeesRepository.DeleteEmployee(request.Id);
        }
    }
}
