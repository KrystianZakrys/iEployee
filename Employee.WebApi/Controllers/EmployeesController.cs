using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iEmployee.CommandQuery;
using iEmployee.Domain.Employees;
using iEmployee.CommandQuery.Query;
using MediatR;
using System.Threading;
using Microsoft.AspNetCore.Cors;
using iEmployee.CommandQuery.Command;
using iEmployee.Contracts;
using iEmployee.CommandQuery.Command.Employees;
using iEmployee.Contracts.Models;
using iEmployee.Contracts.Criteria;
using iEmployee.CommandQuery.Query.Projects;

namespace iEmployee.WebApi.Controllers
{
    /// <summary>
    /// Employee API Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Injected MediatR</param>
        public EmployeesController( IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets employees list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
            => this.Ok(await this.mediator.Send(new GetEmployeesQuery(), CancellationToken.None));

        /// <summary>
        /// Get employee data
        /// </summary>
        /// <param name="id">Employee identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(Guid id)
            => this.Ok(await this.mediator.Send(new GetEmployeeQuery() { Id = id }, CancellationToken.None));

        /// <summary>
        /// Updates employee data
        /// </summary>
        /// <param name="id">Employee identifier</param>
        /// <param name="employee">Employee updated model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeDTO employee)
            => this.Ok(await this.mediator.Send(new UpdateEmployeeCommand(id, employee), CancellationToken.None));
    
        /// <summary>
        /// Adds new employee 
        /// </summary>
        /// <param name="employee">Employee model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee([FromBody] EmployeeDTO employee)
            =>  this.Ok(await this.mediator.Send(new AddEmployeeCommand(employee), CancellationToken.None));

        /// <summary>
        /// Deletes employee
        /// </summary>
        /// <param name="id">Employee identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDTO>> DeleteEmployee(Guid id)
            => this.Ok(await this.mediator.Send(new DeleteEmployeeCommand(id), CancellationToken.None));

        /// <summary>
        /// Assigns employee to project
        /// </summary>
        /// <param name="employeeId">Employee identifier</param>
        /// <param name="projectId">Project identifier</param>
        /// <returns></returns>
        [HttpPut("assign/{employeeId}/{projectId}")]
        public async Task<IActionResult> AssignToProject(Guid employeeId, Guid projectId)
            => this.Ok(await this.mediator.Send(new AssignToProjectCommand(employeeId, projectId), CancellationToken.None));

        /// <summary>
        /// Unassigns employee from project
        /// </summary>
        /// <param name="employeeId">Employee identifier</param>
        /// <param name="projectId">Project identifier</param>
        /// <returns></returns>
        [HttpPut("unassign/{employeeId}/{projectId}")]
        public async Task<IActionResult> UnassignFromProject(Guid employeeId, Guid projectId)
          => this.Ok(await this.mediator.Send(new UnassignFromProjectCommand(employeeId, projectId), CancellationToken.None));

        /// <summary>
        /// Changes employee position
        /// </summary>
        /// <param name="employeeId">Employee identifier</param>
        /// <param name="jobHistorySaveModel">position save model</param>
        /// <returns></returns>
        [HttpPost("changePos/{employeeId}")]
        public async Task<IActionResult> ChangeEmployeePosition(Guid employeeId, [FromBody] JobHistoryDTO jobHistorySaveModel)
           => this.Ok(await this.mediator.Send(new ChangeEmployeePositionCommand(employeeId, jobHistorySaveModel), CancellationToken.None));

        /// <summary>
        /// Gets employees list filtered by criteria
        /// </summary>
        /// <param name="employeeCriteria">Criteria values</param>
        /// <returns></returns>
        [Route("Find")]
        [HttpGet]
        public async Task<ActionResult<EmployeeDTO>> Find([FromQuery] EmployeeCriteria employeeCriteria)
            => this.Ok(await this.mediator.Send(new FindEmployeeQuery(employeeCriteria), CancellationToken.None));

        /// <summary>
        /// Gets projects for employee
        /// </summary>
        /// <param name="id">Employee identifier</param>
        /// <returns></returns>
        [HttpGet("Projects/{employeeId}")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetEmployeeProjects(Guid employeeId)
            => this.Ok(await this.mediator.Send(new GetEmployeeProjectsQuery() { EmployeeId = employeeId }, CancellationToken.None));
    }
}
