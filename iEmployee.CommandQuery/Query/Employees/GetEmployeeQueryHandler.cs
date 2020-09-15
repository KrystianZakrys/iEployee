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
using System.Net.Http.Headers;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query handler for <see cref="GetEmployeeQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeDTO>
    {
        private readonly IEmployeesRepository employeesRepository;

        public GetEmployeeQueryHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetEmployeeQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>employee DTO</returns>
        public async Task<EmployeeDTO> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await employeesRepository.GetEmployee(request.Id);
            return new EmployeeDTO()
            {
                Id = employee.Id,
                Address = new AddressDTO() {
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
                Position = employee.JobHistories != null && employee.JobHistories.Any(j => j.EmployeeId == employee.Id && j.EndDate == null) ? new PositionDTO()
                {
                    Code = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Code,
                    Id = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Id,
                    Name = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Position.Name,
                    EndDate = employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.EndDate,
                    Salary = (decimal)(employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.Salary),
                    StartDate = (DateTime)(employee.JobHistories.Where(j => j.EndDate == null).FirstOrDefault()?.StartDate)

                } : new PositionDTO()
            };
        }
    }
}
