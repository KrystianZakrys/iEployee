using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.Employees
{
    public class ChangeEmployeePositionCommandHandler : ICommandHandler<ChangeEmployeePositionCommand, bool>
    {
        public IEmployeesRepository employeesRepository;
        public IPositionsRepository positionsRepository;
        public ChangeEmployeePositionCommandHandler(IEmployeesRepository employeesRepository, IPositionsRepository positionsRepository)
        {
            this.employeesRepository = employeesRepository;
            this.positionsRepository = positionsRepository;
        }
        public async Task<bool> Handle(ChangeEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            var employee = await this.employeesRepository.GetEmployee(request.EmployeeId);
            var position = await this.positionsRepository.GetPosition(request.PositionId);
            employee.ChangePosition(position, request.StartDate,request.Salary);
            return await this.employeesRepository.UpdateEmployee(request.EmployeeId, employee);
        }
    }
}
