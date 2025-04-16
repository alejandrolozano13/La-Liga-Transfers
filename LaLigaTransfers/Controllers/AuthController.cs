using Applicatiom.DTOs;
using Applicatiom.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var userDto = await _authService.AuthenticateUser(loginDto);
            return Ok(new
            {
                Token= userDto.Token,
                User = userDto.User
            });
        }
    }
}