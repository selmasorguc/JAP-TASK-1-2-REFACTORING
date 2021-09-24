using System.Threading.Tasks;
using API.DTOs;
using API.Entity;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        //return average rating of a movie with given movieId
        [HttpGet("average/{movieId}")]
        public async Task<ActionResult<ServiceResponse<double>>> GetAverageRating(int movieId)
        {
            var response = await _ratingService.GetAverageRatingAsync(movieId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        //add new rating to a movie and a new rating to the db
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