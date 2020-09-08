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
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, bool>
    {
        public IEmployeesRepository employeesRepository;
        public DeleteEmployeeCommandHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
           return await this.employeesRepository.DeleteEmployee(request.Id);
        }
    }
}
