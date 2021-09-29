namespace API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.Core.DTOs;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Caluclates and returns current average rating of a media by media id
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Average Rating as double</returns>
        [HttpGet("average/{movieId}")]
        public async Task<ActionResult<ServiceResponse<double>>> GetAverageRating(int movieId)
        {
            var response = await _ratingService.GetAverageRatingAsync(movieId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        /// <summary>
        /// Adds a new rating to the DB and updates the media with this new rating
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>New average rating of the media as double</returns>
        [HttpPost("add")]
        public async Task<ActionResult<double>> AddRating(RatingDto rating)
        {
            var response = new ServiceResponse<double>();
            response = await _ratingService.RateMovieAsync(rating);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
    }
}
