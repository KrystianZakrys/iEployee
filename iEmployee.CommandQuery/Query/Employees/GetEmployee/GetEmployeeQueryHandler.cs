using System;
using System.Collections.Generic;
using System.Text;
using iEmployee.Infrastructure.Query;
using iEmployee.Domain.Employees;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iEmployee.Contracts;
using iEmployee.Infrastructure.Repositories;

namespace iEmployee.CommandQuery.Query
{
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeSaveModel>
    {
        private readonly IEmployeesRepository employeesRepository;

        public GetEmployeeQueryHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public async Task<EmployeeSaveModel> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await this.employeesRepository.GetEmployee(request.Id);
            return new EmployeeSaveModel()
            {
                Id = employee.Id,
                Address = new AddressSaveModel() { 
                    City = employee.Address?.City, 
                    Country = employee.Address?.Country, 
                    Street = employee.Address?.Street, 
                    ZipCode = employee.Address?.ZipCode 
                },
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Sex = employee.Sex.ToString(),
                BirthDate = employee.BirthDate
            };
        }
    }
}
