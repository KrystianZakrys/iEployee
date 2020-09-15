using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command.Employees
{
    /// <summary>
    /// Command handler for <see cref="AssignToProjectCommand"/> implementing <see cref="ICommandHandler{TCommand, TResult}"/>
    /// </summary>
    public class AssignToProjectCommandHandler : ICommandHandler<AssignToProjectCommand, bool>
    {
        private IUnitOfWork unitOfWork;
        public AssignToProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;          
        }
        /// <summary>
        /// Handler for command 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <seealso cref="AssignToProjectCommand"/>
        /// <returns></returns>
        public async Task<bool> Handle(AssignToProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await unitOfWork.EmployeesRepository.GetEmployee(request.EmployeeId);
                var project = await unitOfWork.ProjectsRepository.GetProject(request.ProjectId);
                employee.AssignEmployeeProject(project);
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
