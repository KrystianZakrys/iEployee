using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iEmployee.CommandQuery.Command.Projects;
using iEmployee.CommandQuery.Query.Projects;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iEmployee.Contracts;
using iEmployee.CommandQuery.Command;
using iEmployee.CommandQuery.Query;

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
        public async Task<ActionResult<IEnumerable<ProjectSaveModel>>> GetProjects()
            => this.Ok(await this.mediator.Send(new GetProjectsQuery(), CancellationToken.None));

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectSaveModel>> GetProject(Guid id)
            => this.Ok(await this.mediator.Send(new GetProjectQuery() { Id = id }, CancellationToken.None));

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectSaveModel>> PostProject([FromBody] ProjectSaveModel project)
            => this.Ok(await this.mediator.Send(new AddProjectCommand(project), CancellationToken.None));

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutProject(Guid id, ProjectSaveModel project)
            => this.Ok(await this.mediator.Send(new UpdateProjectCommand(id, project), CancellationToken.None));
        
        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProject(Guid id)
            => this.Ok(await this.mediator.Send(new DeleteProjectCommand(id), CancellationToken.None));

        // GET: api/Projects/Employee/5
        [HttpGet("NotAssigned/{id}")]
        public async Task<ActionResult<IEnumerable<ProjectSaveModel>>> GetNotAssignedProjects(Guid id)
            => this.Ok(await this.mediator.Send(new GetNotAssignedProjectQuery() { EmployeeId = id }, CancellationToken.None));

        // GET: api/Projects/Employee/5
        [HttpGet("Employees/{projectId}")]
        public async Task<ActionResult<IEnumerable<EmployeeSaveModel>>> GetProjectEmployees(Guid projectId)
            => this.Ok(await this.mediator.Send(new GetProjectEmployeesQuery() { ProjectId = projectId }, CancellationToken.None));

    }
}
