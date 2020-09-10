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
    public class GetProjectEmployeesQueryHandler : IQueryHandler<GetProjectEmployeesQuery, IEnumerable<EmployeeSaveModel>>
    {
        private readonly IEmployeesRepository employeesRepository;

        public GetProjectEmployeesQueryHandler(IEmployeesRepository employeesRepository)
        {            
            this.employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<EmployeeSaveModel>> Handle(GetProjectEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await employeesRepository.GetEmployeesForProject(request.ProjectId);
            var employeeModels = employees.Select(x => new EmployeeSaveModel()
                {
                    Id = x.Id,
                    Address = new AddressSaveModel() { City = x.Address?.City, Country = x.Address?.Country, Street = x.Address?.Street, ZipCode = x.Address?.ZipCode },
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Sex = x.Sex.ToString(),
                    BirthDate = x.BirthDate,
                    ManagerName = x.Manager != null ? x.Manager.Employee.FirstName + ' ' + x.Manager.Employee.LastName : "",
                    Position = x.JobHistories != null && x.JobHistories.Any(j => j.EmployeeId == x.Id && j.EndDate == null) ? new PositionSaveModel()
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
