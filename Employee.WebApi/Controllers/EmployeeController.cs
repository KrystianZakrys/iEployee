using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iEmployee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //[Route("{id}")]
        //[HttpGet]ojj
        //public Task<EditUserModel> Get(Guid id)
        //{
        //    return Query(p => p.OfType<GetUserQuery>()).Execute(id);
        //}
    }
}
