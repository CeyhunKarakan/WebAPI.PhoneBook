using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Data;
using WebAPI.PhoneBook.Interfaces;

namespace WebAPI.PhoneBook.Controllers
{
    [EnableCors]
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

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var addedUser = await _userRepository.CreateAsync(user);
            return Created(string.Empty, addedUser);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var checkUser = await _userRepository.GetByIdAsync(user.UUID);
            if (checkUser == null)
            {
                return NotFound(user.UUID);
            }
                await _userRepository.UpdateAsync(user);
                return NoContent(); 
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove (int id)
        {
            var checkUser = await _userRepository.GetByIdAsync(id);
            if (checkUser == null)
            {
                return NotFound(id);
            }
            await _userRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
