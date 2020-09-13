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
    /// <summary>
    /// Query handler for <see cref="GetManagersQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetManagersQueryHandler : IQueryHandler<GetManagersQuery, IEnumerable<ManagerDTO>>
    {
        private readonly IManagersRepository managersRepository;

        public GetManagersQueryHandler(IManagersRepository managersRepository)
        {
            this.managersRepository = managersRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetManagersQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>manager DTO list</returns>
        public async Task<IEnumerable<ManagerDTO>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
        {
            var managers = await this.managersRepository.GetManagers();
            var managerModels = managers.Select(x => new ManagerDTO()
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
