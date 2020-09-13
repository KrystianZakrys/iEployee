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
        public IEmployeesRepository employeesRepository;
        public IProjectsRepository projectsRepository;
        public AssignToProjectCommandHandler(IEmployeesRepository employeesRepository, IProjectsRepository projectsRepository)
        {
            this.employeesRepository = employeesRepository;
            this.projectsRepository = projectsRepository;
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
            var employee = await this.employeesRepository.GetEmployee(request.EmployeeId);
            var project = await this.projectsRepository.GetProject(request.ProjectId);
            employee.AssignEmployeeProject(project);            
            return await this.employeesRepository.UpdateEmployee(request.EmployeeId, employee);
        }
    }
}
