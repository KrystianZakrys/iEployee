using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeesRepository employeesRepository;
        public UpdateEmployeeCommandHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Employee.Create(request.FirstName, request.LastName, request.Sex, request.BirthDate
                , Address.CreateFromModel(request.Address));
            return  await this.employeesRepository.UpdateEmployee(request.EmployeeId, employee);
        }
    }
}
