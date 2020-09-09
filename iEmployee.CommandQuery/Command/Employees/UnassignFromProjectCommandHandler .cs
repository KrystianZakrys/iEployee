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
    public class UnassignFromProjectCommandHandler : ICommandHandler<UnassignFromProjectCommand, bool>
    {
        public IEmployeesRepository employeesRepository;
        public IProjectsRepository projectsRepository;
        public UnassignFromProjectCommandHandler(IEmployeesRepository employeesRepository, IProjectsRepository projectsRepository)
        {
            this.employeesRepository = employeesRepository;
            this.projectsRepository = projectsRepository;
        }
        public async Task<bool> Handle(UnassignFromProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await this.employeesRepository.GetEmployee(request.EmployeeId);
            var project = await this.projectsRepository.GetProject(request.ProjectId);
            employee.UnassignEmployeeProject(project);            
            return await this.employeesRepository.UpdateEmployee(request.EmployeeId, employee);
        }
    }
}
