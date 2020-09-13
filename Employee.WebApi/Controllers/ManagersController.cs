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
    /// <summary>
    /// Managers API Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IMediator mediator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Injected MediatR</param>
        public ManagersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets managers list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerDTO>>> GetManagers()
            => this.Ok(await this.mediator.Send(new GetManagersQuery(), CancellationToken.None));

        /// <summary>
        /// Get manager
        /// </summary>
        /// <param name="id">manager identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerDTO>> GetManager(Guid id)
            => this.Ok(await this.mediator.Send(new GetManagerQuery() { Id = id }, CancellationToken.None));

        /// <summary>
        /// Adds manager
        /// </summary>
        /// <param name="manager">manager data model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ManagerDTO>> PostManager([FromBody] ManagerDTO manager)
            => this.Ok(await this.mediator.Send(new AddManagerCommand(manager), CancellationToken.None));

        /// <summary>
        /// Updates manager
        /// </summary>
        /// <param name="id">manager identifier</param>
        /// <param name="manager">manager updated data model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutManager(Guid id, ManagerDTO manager)
            => this.Ok(await this.mediator.Send(new UpdateManagerCommand(id, manager), CancellationToken.None));

        /// <summary>
        /// Deletes manager
        /// </summary>
        /// <param name="id">manager identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteManager(Guid id)
            => this.Ok(await this.mediator.Send(new DeleteManagerCommand(id), CancellationToken.None));
    }
}
