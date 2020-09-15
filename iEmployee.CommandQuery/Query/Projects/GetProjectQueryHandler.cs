using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using iEmployee.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query.Projects
{
    /// <summary>
    /// Query handler for <see cref="GetProjectQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectDTO>
    {
        private readonly IProjectsRepository projectsRepository;
        public GetProjectQueryHandler(IProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetProjectQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>project DTO</returns>
        public async Task<ProjectDTO> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await projectsRepository.GetProjectWithEmployees(request.Id);
            List<EmployeeDTO> employeeSaveModels = new List<EmployeeDTO>();
            project.Employees.ToList().ForEach(x => { 
                    employeeSaveModels.Add(new EmployeeDTO() {
                            FirstName = x.Employee.FirstName,
                            LastName = x.Employee.LastName,
                            Id = x.Employee.Id
                        }
                    ); 
                }
            );
            return new ProjectDTO() { Id = project.Id, Name = project.Name, Employees = employeeSaveModels };
        }


    }
}
