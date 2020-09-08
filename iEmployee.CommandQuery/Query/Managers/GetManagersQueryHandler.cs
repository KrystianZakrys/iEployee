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
    public class GetManagersQueryHandler : IQueryHandler<GetManagersQuery, IEnumerable<ManagerSaveModel>>
    {
        private readonly IManagersRepository managersRepository;

        public GetManagersQueryHandler(IManagersRepository managersRepository)
        {
            this.managersRepository = managersRepository;
        }

        public async Task<IEnumerable<ManagerSaveModel>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
        {
            var managers = await this.managersRepository.GetManagers();
            var managerModels = managers.Select(x => new ManagerSaveModel()
            {
                ManagerId = x.Id,
                EmployeeId = x.Employee.Id,
                RoomNumber = x.RoomNumber,
                Suboridnates = x.Suboridnates.Select(y => y.Id).ToList()
            }
            ); ;
            return managerModels;
        }
    }
}
