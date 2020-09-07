using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iEmployee.CommandQuery.Command.AddProject;
using iEmployee.CommandQuery.Query.Projects;
using iEmployee.Domain;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iEmployee.Infrastructure.Models;

namespace iEmployee.WebApi.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProjectsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
            => this.Ok(await this.mediator.Send(new GetProjectsQuery(), CancellationToken.None));

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
            => this.Ok(await this.mediator.Send(new GetProjectQuery() { Id = id }, CancellationToken.None));

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectSaveModel>> PostProject([FromBody] ProjectSaveModel project)
            => this.Ok(await this.mediator.Send(new AddProjectCommand(project), CancellationToken.None));
    }
}
