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
        private IUnitOfWork unitOfWork;
        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            try
            {
                var employee = await unitOfWork.EmployeesRepository.GetEmployee(request.EmployeeId);
                employee.Update(request.FirstName, request.LastName, request.BirthDate, request.Sex, Address.CreateFromModel(request.Address));

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
