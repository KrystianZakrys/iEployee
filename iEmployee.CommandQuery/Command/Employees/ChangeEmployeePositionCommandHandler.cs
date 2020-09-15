using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.Employees
{
    /// <summary>
    /// Command handler for <see cref="ChangeEmployeePositionCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class ChangeEmployeePositionCommandHandler : ICommandHandler<ChangeEmployeePositionCommand, bool>
    {
        private IUnitOfWork unitOfWork;
        public ChangeEmployeePositionCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="ChangeEmployeePositionCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(ChangeEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await unitOfWork.EmployeesRepository.GetEmployee(request.EmployeeId);
                var position = await unitOfWork.PositionsRepository.GetPosition(request.PositionId);

                employee.ChangePosition(position, request.StartDate, request.Salary);
                var result = await unitOfWork.EmployeesRepository.UpdateEmployee(employee);
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
