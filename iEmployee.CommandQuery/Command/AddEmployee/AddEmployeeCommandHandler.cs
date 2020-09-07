using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand, Employee>
    {
        private readonly iEmployeeContext db;
        public AddEmployeeCommandHandler(iEmployeeContext db)
        {
            this.db = db;
        }
        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(request.FirstName, request.LastName, request.Address, request.BirthDate, request.Sex);
            await db.Employees.AddAsync(employee);
            db.SaveChanges();
            return employee;
        }
    }
}
