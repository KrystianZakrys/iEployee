using iEmployee.Contracts;
using iEmployee.Infrastructure.Query;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query handler for <see cref="GetPositionsQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetPositionsQueryHandler : IQueryHandler<GetPositionsQuery, IEnumerable<PositionDTO>>
    {
        private readonly IPositionsRepository positionsRepository;

        public GetPositionsQueryHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetPositionsQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>position DTO list</returns>
        public async Task<IEnumerable<PositionDTO>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await positionsRepository.GetPositions();
            var positionsModels = positions.Select(x => new PositionDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }
            );
            return positionsModels;
        }
    }
}
