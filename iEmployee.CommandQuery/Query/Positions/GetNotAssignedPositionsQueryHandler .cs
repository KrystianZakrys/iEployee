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
    public class GetNotAssignedPositionsQueryHandler : IQueryHandler<GetNotAssignedPositionsQuery, ICollection<PositionSaveModel>>
    {
        private readonly IPositionsRepository positionsRepository;
        public GetNotAssignedPositionsQueryHandler(IPositionsRepository positionsRepository)
        {
            this.positionsRepository = positionsRepository;
        }

        public async Task<ICollection<PositionSaveModel>> Handle(GetNotAssignedPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = await this.positionsRepository.GetNotAssignedPosition(request.EmployeeId);
            var positionsSaveModels = new List<PositionSaveModel>();
            positions.ToList().ForEach(p => {
                positionsSaveModels.Add(new PositionSaveModel()
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
