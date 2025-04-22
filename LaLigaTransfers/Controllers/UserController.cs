using Applicatiom.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaTransfers.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add ([FromBody] User user)
        {
            await _userService.Add(user);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update (string id, [FromBody] User user)
        {
            await _userService.Update(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}