using iEmployee.Contracts;
using iEmployee.Domain;
using iEmployee.Infrastructure.Query;
using iEmployee.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iEmployee.CommandQuery.Query
{
    /// <summary>
    /// Query handler for <see cref="GetPositionQuery"/> implements <seealso cref="IQueryHandler{TQuery, TResult}"/>
    /// </summary>
    public class GetPositionQueryHandler : IQueryHandler<GetPositionQuery, PositionDTO>
    {
        private readonly IPositionsRepository positionsRepository;
        public GetPositionQueryHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }
        /// <summary>
        /// Handler for query <see cref="GetPositionQuery"/>
        /// </summary>
        /// <param name="request">query</param>
        /// <param name="cancellationToken"><seealso cref="System.Threading.CancellationToken"/></param>
        /// <returns>position DTO</returns>
        public async Task<PositionDTO> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var positon = await this.positionsRepository.GetPosition(request.Id);
            return new PositionDTO() { Id = positon.Id, Name = positon.Name, Code = positon.Code};
        }
    }
}
