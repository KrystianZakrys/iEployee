using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iEmployee.CommandQuery.Command;
using iEmployee.CommandQuery.Query;
using iEmployee.Contracts;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iEmployee.WebApi.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PositionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionSaveModel>>> GetProjects()
            => this.Ok(await this.mediator.Send(new GetPositionsQuery(), CancellationToken.None));

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionSaveModel>> GetProject(Guid id)
            => this.Ok(await this.mediator.Send(new GetPositionQuery() { Id = id }, CancellationToken.None));

        // POST: api/Positions
        [HttpPost]
        public async Task<ActionResult<PositionSaveModel>> PostProject([FromBody] PositionSaveModel project)
            => this.Ok(await this.mediator.Send(new AddPositionCommand(project), CancellationToken.None));

        // PUT: api/Positions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutProject(Guid id, PositionSaveModel project)
            => this.Ok(await this.mediator.Send(new UpdatePositionCommand(id, project), CancellationToken.None));

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProject(Guid id)
            => this.Ok(await this.mediator.Send(new DeletePositionCommand(id), CancellationToken.None));
        // GET: api/Positions/Employee/5
        [HttpGet("NotAssigned/{id}")]
        public async Task<ActionResult<IEnumerable<PositionSaveModel>>> GetNotAssignedProjects(Guid id)
            => this.Ok(await this.mediator.Send(new GetNotAssignedPositionsQuery(){ EmployeeId = id }, CancellationToken.None));
    }
}
