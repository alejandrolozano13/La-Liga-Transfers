using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaTransfers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "CanCreateTransfers")]
        public async Task<IActionResult> Add()
        {

            return Ok();
        }

        [HttpPatch]
        [Authorize(Policy = "CanManageTransfers")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = "CanDeleteTransfers")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}