using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Data;
using WebAPI.PhoneBook.Interfaces;

namespace WebAPI.PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _userRepository.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }


    }
}
