using CachingService.Data.Contracts;
using CachingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CachingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _platfromRepository;
        public PlatformController(IPlatformRepository platfromRepository)
        {
            _platfromRepository = platfromRepository;
        }
        [HttpGet("id",Name="GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            var platform = _platfromRepository.GetPlatformById(id);
            if (platform != null) { return Ok(platform); }
            return NotFound();
        }
        [HttpPost("CreatePlatfrom")]
        public ActionResult<Platform> CreatePlatfromAsync(Platform platform)
        {
            _platfromRepository.CreatePlatform(platform);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platform.Id }, platform);
        }
    }
}
