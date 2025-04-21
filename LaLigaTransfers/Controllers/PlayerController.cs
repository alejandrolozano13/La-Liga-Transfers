using Applicatiom.DTOs;
using Applicatiom.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaTransfers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _playerService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _playerService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "CanManagePlayers")]
        public async Task<IActionResult> Add([FromBody] PlayerDto player)
        {
            await _playerService.Add(player);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(Policy = "CanManagePlayers")]
        public async Task<IActionResult> Update(string id, [FromBody] Player player)
        {
            await _playerService.Update(id, player);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanManagePlayers")]
        public async Task<IActionResult> Delete(string id)
        {
            await _playerService.Delete(id);
            return NoContent();
        }
    }
}