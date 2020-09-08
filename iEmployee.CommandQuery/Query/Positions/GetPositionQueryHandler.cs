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
    public class GetPositionQueryHandler : IQueryHandler<GetPositionQuery, PositionSaveModel>
    {
        private readonly IPositionsRepository positionsRepository;
        public GetPositionQueryHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }

        public async Task<PositionSaveModel> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var positon = await this.positionsRepository.GetPosition(request.Id);
            return new PositionSaveModel() { Id = positon.Id, Name = positon.Name, Code = positon.Code};
        }
    }
}
