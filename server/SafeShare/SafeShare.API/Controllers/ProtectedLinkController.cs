using Microsoft.AspNetCore.Mvc;
using SafeShare.API.Models;
using SafeShare.CORE.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SafeShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedLinkController : ControllerBase
    {
        private readonly IProtectedLinkService _protectedLinkService;

        public ProtectedLinkController(IProtectedLinkService protectedLinkService)
        {
            _protectedLinkService = protectedLinkService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProtectedLink([FromBody] ProtectedLinkPostModel request)
        {
            var result = await _protectedLinkService.CreateProtectedLinkAsync(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        // GET: api/protectedlink/{linkId}
        [HttpGet("{linkId}")]
        public async Task<IActionResult> GetProtectedLink(int linkId)
        {
            var protectedLink = await _protectedLinkService.GetProtectedLinkAsync(linkId);
            if (protectedLink != null)
                return Ok(protectedLink);
            return NotFound();
        }
        [HttpPost("{linkId}/validate")]
        public async Task<IActionResult> ValidateProtectedLink(int linkId, [FromBody] string password)
        {
            var result = await _protectedLinkService.ValidateProtectedLinkAsync(linkId, password);
            if (result.Success)
                return Ok(result);
            return Unauthorized();
        }

        
    }
}
