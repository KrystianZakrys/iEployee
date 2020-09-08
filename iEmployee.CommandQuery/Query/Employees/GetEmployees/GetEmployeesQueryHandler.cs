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

namespace iEmployee.CommandQuery.Query
{
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, IEnumerable<EmployeeSaveModel>>
    {
        private readonly IEmployeesRepository employeesRepository;

        public GetEmployeesQueryHandler(IEmployeesRepository employeesRepository)
        {            
            this.employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<EmployeeSaveModel>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await employeesRepository.GetEmployees();
            var employeeModels = employees.Select(x => new EmployeeSaveModel()
                { 
                    Id = x.Id,
                    Address = new AddressSaveModel() { City = x.Address?.City,Country = x.Address?.Country, Street = x.Address?.Street, ZipCode = x.Address?.ZipCode},
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Sex = x.Sex.ToString(),
                    BirthDate = x.BirthDate
                }
            );
            return employeeModels;
        }
    }
}
