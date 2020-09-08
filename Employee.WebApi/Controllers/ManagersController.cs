using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iEmployee.CommandQuery.Command;
using iEmployee.CommandQuery.Query;
using iEmployee.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iEmployee.WebApi.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerSaveModel>>> GetManagers()
            => this.Ok(await this.mediator.Send(new GetManagersQuery(), CancellationToken.None));

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerSaveModel>> GetManager(Guid id)
            => this.Ok(await this.mediator.Send(new GetManagerQuery() { Id = id }, CancellationToken.None));

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ManagerSaveModel>> PostManager([FromBody] ManagerSaveModel project)
            => this.Ok(await this.mediator.Send(new AddManagerCommand(project), CancellationToken.None));

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutManager(Guid id, ManagerSaveModel project)
            => this.Ok(await this.mediator.Send(new UpdateManagerCommand(id, project), CancellationToken.None));

        //DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteManager(Guid id)
            => this.Ok(await this.mediator.Send(new DeleteManagerCommand(id), CancellationToken.None));
    }
}
