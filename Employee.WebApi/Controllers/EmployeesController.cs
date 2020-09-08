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

namespace iEmployee.WebApi.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeesController( IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSaveModel>>> GetEmployees()
            => this.Ok(await this.mediator.Send(new GetEmployeesQuery(), CancellationToken.None));

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSaveModel>> GetEmployee(Guid id)
            => this.Ok(await this.mediator.Send(new GetEmployeeQuery() { Id = id }, CancellationToken.None));


        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeSaveModel employee)
            => this.Ok(await this.mediator.Send(new UpdateEmployeeCommand(id, employee), CancellationToken.None));

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeSaveModel>> PostEmployee([FromBody] EmployeeSaveModel employee)
            =>  this.Ok(await this.mediator.Send(new AddEmployeeCommand(employee), CancellationToken.None));

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeSaveModel>> DeleteEmployee(Guid id)
            => this.Ok(await this.mediator.Send(new DeleteEmployeeCommand(id), CancellationToken.None));

        [HttpPut("{employeeId}/{projectId}")]
        public async Task<IActionResult> AssignToProject(Guid employeeId, Guid projectId)
            => this.Ok(await this.mediator.Send(new AssignToProjectCommand(employeeId, projectId), CancellationToken.None));
    }
}
