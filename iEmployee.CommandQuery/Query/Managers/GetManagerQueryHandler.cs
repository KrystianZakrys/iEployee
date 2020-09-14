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
    /// Query handler for <see cref="GetManagerQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetManagerQueryHandler : IQueryHandler<GetManagerQuery, ManagerDTO>
    {
        private readonly IManagersRepository managersRepository;
        public GetManagerQueryHandler(IManagersRepository managersRepository)
        {
            this.managersRepository = managersRepository;
        }

        /// <summary>
        /// Handler for query <see cref="GetManagerQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>manager DTO</returns>
        public async Task<ManagerDTO> Handle(GetManagerQuery request, CancellationToken cancellationToken)
        {
            var manager = await this.managersRepository.GetManager(request.Id);
            return new ManagerDTO() { EmployeeId = manager.Employee.Id, RoomNumber = manager.RoomNumber,
                ManagerId = manager.Id, Subordinates = manager.Subordinates.Select(x => x.Id).ToList() };
        }
    }
}
