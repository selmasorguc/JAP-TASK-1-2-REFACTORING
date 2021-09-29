namespace MovieApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.Core.DTOs;
    using MovieApp.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        /// <summary>
        /// Gets media (movies or tv shows) from the database
        /// When no params have been sent it returns 20 top rated media (tv shows and movies together)
        /// Check the MediaParams class in Core DTOs
        /// </summary>
        /// <param name="movieParams"></param>
        /// <returns>List of media</returns>
        [HttpGet]
        
        public async Task<ActionResult<List<MediaDto>>> GetMedia(
            [FromQuery] MediaParams movieParams)
        {
            var movies = await _mediaService.GetMediaAsync(movieParams);
            return Ok(movies);
        }
    }
}
