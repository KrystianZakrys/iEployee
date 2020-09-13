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
    /// <summary>
    /// Positions API Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator mediator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Injected MediatR</param>
        public PositionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets projects list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDTO>>> GetPositions()
            => this.Ok(await this.mediator.Send(new GetPositionsQuery(), CancellationToken.None));

        /// <summary>
        /// Gets project 
        /// </summary>
        /// <param name="id">project identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDTO>> GetPosition(Guid id)
            => this.Ok(await this.mediator.Send(new GetPositionQuery() { Id = id }, CancellationToken.None));

        /// <summary>
        /// Adds project
        /// </summary>
        /// <param name="project">project data model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PositionDTO>> PostPosition([FromBody] PositionDTO project)
            => this.Ok(await this.mediator.Send(new AddPositionCommand(project), CancellationToken.None));

        /// <summary>
        /// Updates project
        /// </summary>
        /// <param name="id">project identifier</param>
        /// <param name="project">project updated data model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutPosition(Guid id, PositionDTO project)
            => this.Ok(await this.mediator.Send(new UpdatePositionCommand(id, project), CancellationToken.None));

        /// <summary>
        /// Deletes project
        /// </summary>
        /// <param name="id">project identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePosition(Guid id)
            => this.Ok(await this.mediator.Send(new DeletePositionCommand(id), CancellationToken.None));
        
        /// <summary>
        /// Gets positions actually not assigned to specified employee
        /// </summary>
        /// <param name="id">employee identifier</param>
        /// <returns></returns>
        [HttpGet("NotAssigned/{id}")]
        public async Task<ActionResult<IEnumerable<PositionDTO>>> GetNotAssignedPositions(Guid id)
            => this.Ok(await this.mediator.Send(new GetNotAssignedPositionsQuery(){ EmployeeId = id }, CancellationToken.None));
    }
}
