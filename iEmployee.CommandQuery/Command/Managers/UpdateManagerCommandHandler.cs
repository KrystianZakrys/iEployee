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
    /// Command handler for <see cref="UpdateManagerCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class UpdateManagerCommandHandler : ICommandHandler<UpdateManagerCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateManagerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="UpdateManagerCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subordinates = new List<Employee>();
                foreach (var subordinate in request.Subordinates)
                {
                    subordinates.Add(await unitOfWork.EmployeesRepository.GetEmployee(subordinate));
                }
                var manager = await unitOfWork.ManagersRepository.GetManager(request.ManagerId);

                manager.Update(request.RoomNumber, subordinates);
                var result = await unitOfWork.ManagersRepository.UpdateManager(manager);
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
