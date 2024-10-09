using Microsoft.AspNetCore.Mvc;

namespace BARBACENA_10092024.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly ILogger<VideosController> _logger;

        public VideosController(ILogger<VideosController> logger)
        {
            _logger = logger;
        }
    }
}