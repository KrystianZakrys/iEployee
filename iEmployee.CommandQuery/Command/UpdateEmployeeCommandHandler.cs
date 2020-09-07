using iEmployee.Domain;
using iEmployee.Domain.Employees;
using iEmployee.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Command
{
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly iEmployeeContext db;
        public UpdateEmployeeCommandHandler(iEmployeeContext db)
        {
            this.db = db;
        }
        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = db.Employees.Find(request.Id);
            //employee = request....;
            await db.SaveChangesAsync();
            return employee;
        }
    }
}
