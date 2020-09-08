using iEmployee.Contracts.Models;
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
    public class GetManagerQueryHandler : IQueryHandler<GetManagerQuery, ManagerSaveModel>
    {
        private readonly IManagersRepository managersRepository;
        public GetManagerQueryHandler(IManagersRepository managersRepository)
        {
            this.managersRepository = managersRepository;
        }

        public async Task<ManagerSaveModel> Handle(GetManagerQuery request, CancellationToken cancellationToken)
        {
            var manager = await this.managersRepository.GetManager(request.Id);
            return new ManagerSaveModel() { EmployeeId = manager.Employee.Id, RoomNumber = manager.RoomNumber,
                ManagerId = manager.Id, Suboridnates = manager.Suboridnates.Select(x => x.Id).ToList() };
        }
    }
}
