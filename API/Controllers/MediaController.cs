using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<MediaDto>>> SearchMediaAsync(
            [FromQuery] string query)
        {
            return Ok(await _mediaService.SearchMediaAsync(query));
        }

        [HttpGet]
        public async Task<ActionResult<List<MediaDto>>> GetMoviesPaged(
            [FromQuery] MediaParams movieParams)
        {
            var movies = await _mediaService.GetPagedAsync(movieParams);
            return Ok(movies);
        }
    }
}