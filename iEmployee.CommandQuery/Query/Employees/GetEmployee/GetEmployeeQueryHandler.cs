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
                BirthDate = employee.BirthDate,
                ManagerName = employee.Manager != null ? employee.Manager.Employee.FirstName + ' ' + employee.Manager.Employee.LastName : "",
                Position = employee.JobHistories != null && employee.JobHistories.Any(j => j.EmployeeId == employee.Id && j.EndDate == null) ? new PositionSaveModel()
                {
                    Code = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Code,
                    Id = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Id,
                    Name = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Name
                } : null
            };
        }
    }
}
