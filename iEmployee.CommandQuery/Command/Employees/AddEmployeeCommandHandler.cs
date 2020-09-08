using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iEmployee.Contracts;
using iEmployee.Infrastructure.Repositories;

namespace iEmployee.CommandQuery.Command
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand, bool>
    {
        private readonly IEmployeesRepository employeesRepository;
        public AddEmployeeCommandHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }
        public async Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Employee.Create(request.FirstName, request.LastName, request.Sex, request.BirthDate, 
                Address.CreateFromModel(request.Address));
            return await this.employeesRepository.AddEmployeeAsync(employee);
        }
    }
}
