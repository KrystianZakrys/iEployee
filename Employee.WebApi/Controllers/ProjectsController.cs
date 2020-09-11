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
    /// <summary>
    /// Projects API Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator mediator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Injected MediatR</param>
        public ProjectsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get projects list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectSaveModel>>> GetProjects()
            => this.Ok(await this.mediator.Send(new GetProjectsQuery(), CancellationToken.None));

        /// <summary>
        /// Get project
        /// </summary>
        /// <param name="id">Project identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectSaveModel>> GetProject(Guid id)
            => this.Ok(await this.mediator.Send(new GetProjectQuery() { Id = id }, CancellationToken.None));

        /// <summary>
        /// Adds project
        /// </summary>
        /// <param name="project">Project data model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ProjectSaveModel>> PostProject([FromBody] ProjectSaveModel project)
            => this.Ok(await this.mediator.Send(new AddProjectCommand(project), CancellationToken.None));

        /// <summary>
        /// Updates project
        /// </summary>
        /// <param name="id">project identifier</param>
        /// <param name="project">project updated data model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutProject(Guid id, ProjectSaveModel project)
            => this.Ok(await this.mediator.Send(new UpdateProjectCommand(id, project), CancellationToken.None));
        
        /// <summary>
        /// Deletes project
        /// </summary>
        /// <param name="id">project identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProject(Guid id)
            => this.Ok(await this.mediator.Send(new DeleteProjectCommand(id), CancellationToken.None));

        /// <summary>
        /// Gets projects not assigned to specified employee
        /// </summary>
        /// <param name="id">employee identifier</param>
        /// <returns></returns>
        [HttpGet("NotAssigned/{id}")]
        public async Task<ActionResult<IEnumerable<ProjectSaveModel>>> GetNotAssignedProjects(Guid id)
            => this.Ok(await this.mediator.Send(new GetNotAssignedProjectQuery() { EmployeeId = id }, CancellationToken.None));

        /// <summary>
        /// Gets employees list for specified project
        /// </summary>
        /// <param name="projectId">project identifier</param>
        /// <returns></returns>
        [HttpGet("Employees/{projectId}")]
        public async Task<ActionResult<IEnumerable<EmployeeSaveModel>>> GetProjectEmployees(Guid projectId)
            => this.Ok(await this.mediator.Send(new GetProjectEmployeesQuery() { ProjectId = projectId }, CancellationToken.None));

    }
}
