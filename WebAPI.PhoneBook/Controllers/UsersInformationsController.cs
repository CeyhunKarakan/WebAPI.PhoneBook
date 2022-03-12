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
    public class UsersInformationsController : ControllerBase
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public UsersInformationsController(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userInformationRepository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data = await _userInformationRepository.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserInformation userInformation)
        {
            var addeduserInformation = await _userInformationRepository.CreateAsync(userInformation);
            return Created(string.Empty, userInformation);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserInformation userInformation)
        {
            var checkUserInformation = await _userInformationRepository.GetByIdAsync(userInformation.UInfoID);
            if(checkUserInformation == null)
            {
                return NotFound(userInformation.UInfoID);
            }
            await _userInformationRepository.UpdateAsync(userInformation);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkUserInformation = await _userInformationRepository.GetByIdAsync(id);
            if (checkUserInformation == null)
            {
                return NotFound(id);
            }
            await _userInformationRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
