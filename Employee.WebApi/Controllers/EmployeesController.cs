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

namespace iEmployee.WebApi.Controllers
{
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

        //// GET: api/Employees/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        //{
        //    var employee = await this.context.Employees.FindAsync(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return employee;
        //}

        //// PUT: api/Employees/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return BadRequest();
        //    }

        //    this.context.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        await this.context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Employees
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        //{
        //    this.context.Employees.Add(employee);
        //    await this.context.SaveChangesAsync();

        //    return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        //}

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
