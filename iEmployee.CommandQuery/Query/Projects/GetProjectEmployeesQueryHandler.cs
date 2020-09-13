using System;
using System.Collections.Generic;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using iEmployee.Contracts;
using System.Security.Cryptography.X509Certificates;
using iEmployee.Contracts.Models;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query handler for <see cref="GetProjectEmployeesQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetProjectEmployeesQueryHandler : IQueryHandler<GetProjectEmployeesQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly IEmployeesRepository employeesRepository;

        public GetProjectEmployeesQueryHandler(IEmployeesRepository employeesRepository)
        {            
            this.employeesRepository = employeesRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetProjectEmployeesQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>employee DTO list</returns>
        public async Task<IEnumerable<EmployeeDTO>> Handle(GetProjectEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await employeesRepository.GetEmployeesForProject(request.ProjectId);
            var employeeModels = employees.Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    Address = new AddressDTO() { City = x.Address?.City, Country = x.Address?.Country, Street = x.Address?.Street, ZipCode = x.Address?.ZipCode },
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Sex = x.Sex.ToString(),
                    BirthDate = x.BirthDate,
                    ManagerName = x.Manager != null ? x.Manager.Employee.FirstName + ' ' + x.Manager.Employee.LastName : "",
                    Position = x.JobHistories != null && x.JobHistories.Any(j => j.EmployeeId == x.Id && j.EndDate == null) ? new PositionDTO()
                    {
                        Code = x.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Code,
                        Id = x.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Id,
                        Name = x.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Name
                    } : null
                 }
            ); 
            return employeeModels;
        }
    }
}
