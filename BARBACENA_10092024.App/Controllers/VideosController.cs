using BARBACENA_10092024.App.Models;
using BARBACENA_10092024.App.Services.Interface;
using BARBACENA_10092024.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BARBACENA_10092024.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _service;

        public VideosController(IVideoService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllVideos()
        {
            var videos = await _service.GetAllVideos();
            return Ok(videos);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadVideo([FromForm] VideoRequestModel request)
        {
            request.Validate();

            if (!string.IsNullOrEmpty(request.ErrorMessage))
            {
                return BadRequest(request.ErrorMessage);
            }

            var result = await _service.UploadVideo(request);
            return Ok(result);
        }
    }
}