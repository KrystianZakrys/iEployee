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
        public IEmployeesRepository employeesRepository;
        public IPositionsRepository positionsRepository;
        public ChangeEmployeePositionCommandHandler(IEmployeesRepository employeesRepository, IPositionsRepository positionsRepository)
        {
            this.employeesRepository = employeesRepository;
            this.positionsRepository = positionsRepository;
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
            var employee = await employeesRepository.GetEmployee(request.EmployeeId);
            var position = await positionsRepository.GetPosition(request.PositionId);
            employee.ChangePosition(position, request.StartDate,request.Salary);
            return await employeesRepository.UpdateEmployee(request.EmployeeId, employee);
        }
    }
}
