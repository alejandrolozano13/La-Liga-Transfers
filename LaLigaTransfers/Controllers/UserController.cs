using Applicatiom.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add ([FromBody] User user)
        {
            await _userService.Add(user);
            return Ok();
        }
    }
}