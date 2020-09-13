using iEmployee.CommandQuery.Query.Projects;
using iEmployee.Contracts;
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
    /// Query handler for <see cref="GetNotAssignedPositionsQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetNotAssignedPositionsQueryHandler : IQueryHandler<GetNotAssignedPositionsQuery, ICollection<PositionDTO>>
    {
        private readonly IPositionsRepository positionsRepository;
        public GetNotAssignedPositionsQueryHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetNotAssignedPositionsQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>position DTO list</returns>
        public async Task<ICollection<PositionDTO>> Handle(GetNotAssignedPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await this.positionsRepository.GetNotAssignedPosition(request.EmployeeId);
            var positionsSaveModels = new List<PositionDTO>();
            positions.ToList().ForEach(p => {
                positionsSaveModels.Add(new PositionDTO()
                {
                   Code = p.Code,
                   Id = p.Id,
                   Name = p.Name
                });
            });
            return positionsSaveModels;
        }
    }
}
