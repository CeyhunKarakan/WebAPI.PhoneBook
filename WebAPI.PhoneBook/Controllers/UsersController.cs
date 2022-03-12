using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(new[] { new{ Name = "Ali", Age = 15 } });

        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(new[] { new { Name = "Aslı", Age = 24 } });
        }
    }
}
