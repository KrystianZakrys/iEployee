﻿using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class UpdateManagerCommandHandler : ICommandHandler<UpdateManagerCommand, bool>
    {
        private readonly IManagersRepository managersRepository;
        private readonly IEmployeesRepository employeesRepository;
        public UpdateManagerCommandHandler(IManagersRepository managersRepository, IEmployeesRepository employeesRepository)
        {
            this.managersRepository = managersRepository;
            this.employeesRepository = employeesRepository;
        }
        public async Task<bool> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            var employee = await this.employeesRepository.GetEmployee(request.EmployeeId);
            var subordinates = new List<Employee>();
            foreach (var subordinate in request.Suboridnates)
            {
                subordinates.Add(await this.employeesRepository.GetEmployee(subordinate));
            }
            var manager = Manager.Create(request.RoomNumber,employee,subordinates);
            return await this.managersRepository.UpdateManager(request.ManagerId, manager);
        }
    }
}
