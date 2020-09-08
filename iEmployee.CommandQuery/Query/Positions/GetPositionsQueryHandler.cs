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
    public class GetPositionsQueryHandler : IQueryHandler<GetPositionsQuery, IEnumerable<PositionSaveModel>>
    {
        private readonly IPositionsRepository positionsRepository;

        public GetPositionsQueryHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }

        public async Task<IEnumerable<PositionSaveModel>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await positionsRepository.GetPositions();
            var positionsModels = positions.Select(x => new PositionSaveModel()
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
