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
        private readonly IUnitOfWork unitOfWork;
        public AddManagerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            try
            {
                var employee = await unitOfWork.EmployeesRepository.GetEmployee(request.EmployeeId);
                var subordinates = new List<Employee>();

                foreach (var subordinate in request.Subordinates)
                {
                    subordinates.Add(await unitOfWork.EmployeesRepository.GetEmployee(subordinate));
                }

                var manager = Manager.Create(request.RoomNumber, employee, subordinates);
                var result = await unitOfWork.ManagersRepository.AddManagerAsync(manager);
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
