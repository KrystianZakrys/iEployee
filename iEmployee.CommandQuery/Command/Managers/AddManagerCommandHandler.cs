using iEmployee.Domain.Employees;
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
    /// Command handler for <see cref="AddManagerCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class AddManagerCommandHandler : ICommandHandler<AddManagerCommand, bool>
    {
        private readonly IManagersRepository managersRepository;
        private readonly IEmployeesRepository employeesRepository;
        public AddManagerCommandHandler(IManagersRepository managersRepository, IEmployeesRepository employeesRepository)
        {
            this.managersRepository = managersRepository;
            this.employeesRepository = employeesRepository;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="AddManagerCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(AddManagerCommand request, CancellationToken cancellationToken)
        {
            var employee = await this.employeesRepository.GetEmployee(request.EmployeeId);
            var subordinates = new List<Employee>();

            foreach (var subordinate in request.Subordinates)
            {
                subordinates.Add(await this.employeesRepository.GetEmployee(subordinate));
            }

            var manager = Manager.Create(request.RoomNumber, employee, subordinates);
            return await this.managersRepository.AddManagerAsync(manager);
        }
    }
}
