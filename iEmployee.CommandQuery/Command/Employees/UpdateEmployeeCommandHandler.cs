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
    /// <summary>
    /// Command handler for <see cref="UpdateEmployeeCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeesRepository employeesRepository;
        public UpdateEmployeeCommandHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="UpdateEmployeeCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Employee.Create(request.FirstName, request.LastName, request.Sex, request.BirthDate
                , Address.CreateFromModel(request.Address));
            return  await employeesRepository.UpdateEmployee(request.EmployeeId, employee);
        }
    }
}
