namespace API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Entities.StoredProceduresEntities;
    using MovieApp.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// API end points created for the Task 2 stored procedures testing
    /// </summary>
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _moviesSPService;

        public ReportsController(IReportService moviesSPService)
        {
            _moviesSPService = moviesSPService;
        }

        /// <summary>
        ///Gets 10 movies with the most ratings, ordered by rating descending 
        /// </summary>
        /// <returns>movie ID, movie name, number of ratings, movie rating as Top10Item entity</returns>
        [HttpGet("rated")]
        public async Task<ServiceResponse<List<Top10Item>>> GetTopRated()
        {
            var response = new ServiceResponse<List<Top10Item>>();
            response = await _moviesSPService.GetTop10MoviesAsync();
            return response;
        }

        /// <summary>
        ///Gets 10 movies with the most screenings ordered by descending, for the period start date - end date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>movie ID, movie name, number of screenings as TopScreened entity</returns>
        [HttpGet("screened")]
        public async Task<ServiceResponse<List<TopScreened>>> GetTopScreened(
                                                              DateTime startDate, DateTime endDate)
        {
            var response = new ServiceResponse<List<TopScreened>>();
            response = await _moviesSPService.GetTop10ScreenedAsync(startDate, endDate);
            return response;
        }

        /// <summary>
        ///Gets movies with the most sold tickets that don’t have ratings, grouped by screening
        /// </summary>
        /// <returns>movie ID, movie name, screening, tickets sold as TopSold entity</returns>
        [HttpGet("sold")]
        public async Task<ServiceResponse<List<TopSold>>> GetTopSold()
        {
            var response = new ServiceResponse<List<TopSold>>();
            response = await _moviesSPService.GetTopSoldAsync();
            return response;
        }
    }
}
