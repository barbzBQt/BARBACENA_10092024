﻿using BARBACENA_10092024.App.Services.Interface;
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
    }
}