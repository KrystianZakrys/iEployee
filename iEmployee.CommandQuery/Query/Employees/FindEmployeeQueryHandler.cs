﻿using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query
{
    public class FindEmployeeQueryHandler : IQueryHandler<FindEmployeeQuery, IEnumerable<EmployeeSaveModel>>
    {
        private readonly IEmployeesRepository employeesRepository;

        public FindEmployeeQueryHandler(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<EmployeeSaveModel>> Handle(FindEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await this.employeesRepository.GetEmployees(request.employeeCriteria);
            var employeeModels = employees.ToList().Select(x => new EmployeeSaveModel()
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
