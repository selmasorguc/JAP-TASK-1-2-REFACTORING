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
    /// Defines the <see cref="ReportsController" />.
    /// </summary>
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        /// <summary>
        /// Defines the _moviesSPService.
        /// </summary>
        private readonly IReportService _moviesSPService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="moviesSPService">The moviesSPService<see cref="IReportService"/>.</param>
        public ReportsController(IReportService moviesSPService)
        {
            _moviesSPService = moviesSPService;
        }

        /// <summary>
        /// The GetTopRated.
        /// </summary>
        /// <returns>The <see cref="Task{ServiceResponse{List{Top10Item}}}"/>.</returns>
        [HttpGet("rated")]
        public async Task<ServiceResponse<List<Top10Item>>> GetTopRated()
        {
            var response = new ServiceResponse<List<Top10Item>>();
            response = await _moviesSPService.GetTop10MoviesAsync();
            return response;
        }

        /// <summary>
        /// The GetTopScreened.
        /// </summary>
        /// <param name="startDate">The startDate<see cref="DateTime"/>.</param>
        /// <param name="endDate">The endDate<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="Task{ServiceResponse{List{TopScreened}}}"/>.</returns>
        [HttpGet("screened")]
        public async Task<ServiceResponse<List<TopScreened>>> GetTopScreened(
                                                              DateTime startDate, DateTime endDate)
        {
            var response = new ServiceResponse<List<TopScreened>>();
            response = await _moviesSPService.GetTop10ScreenedAsync(startDate, endDate);
            return response;
        }

        /// <summary>
        /// The GetTopSold.
        /// </summary>
        /// <returns>The <see cref="Task{ServiceResponse{List{TopSold}}}"/>.</returns>
        [HttpGet("sold")]
        public async Task<ServiceResponse<List<TopSold>>> GetTopSold()
        {
            var response = new ServiceResponse<List<TopSold>>();
            response = await _moviesSPService.GetTopSoldAsync();
            return response;
        }
    }
}
