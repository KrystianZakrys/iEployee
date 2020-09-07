using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iEmployee.CommandQuery;
using iEmployee.Domain.Employees;
using iEmployee.CommandQuery.Query.Employees;
using MediatR;
using System.Threading;
using iEmployee.CommandQuery.Query.Employees.GetEmployee;
using Microsoft.AspNetCore.Cors;
using iEmployee.CommandQuery.Command;

namespace iEmployee.WebApi.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly iEmployeeContext context;
        private readonly IMediator mediator;

        public EmployeesController( IMediator mediator)
        {
            //this.context = context;
            this.mediator = mediator;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
            => this.Ok(await this.mediator.Send(new GetEmployeesQuery(), CancellationToken.None));

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
            => this.Ok(await this.mediator.Send(new GetEmployeeQuery() { Id = id }, CancellationToken.None));


        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            //return Ok(await this.mediator.Send(new UpdateEmployeeCommand(employee),CancellationToken.None));

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] EmployeeSaveModel employee)
            =>  this.Ok(await this.mediator.Send(new AddEmployeeCommand(employee), CancellationToken.None));

        //// DELETE: api/Employees/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Employee>> DeleteEmployee(Guid id)
        //{
        //    var employee = await this.context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    this.context.Employees.Remove(employee);
        //    await this.context.SaveChangesAsync();

        //    return employee;
        //}

        //private bool EmployeeExists(Guid id)
        //{
        //    return this.context.Employees.Any(e => e.Id == id);
        //}
    }
}
