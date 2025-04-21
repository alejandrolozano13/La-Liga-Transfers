using Applicatiom.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaTransfers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clubService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "CanManageClubs")]
        public async Task<IActionResult> Add([FromBody] Club club)
        {
            await _clubService.Add(club);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanManageClubs")]
        public async Task<IActionResult> Delete (string id)
        {
            await _clubService.Remove(id);
            return NoContent();
        }
    }
}