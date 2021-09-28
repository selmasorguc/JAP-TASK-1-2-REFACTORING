namespace MovieApp.Core.Interfaces
{
    using MovieApp.Core.DTOs;
    using MovieApp.Core.Entities;
    using System.Threading.Tasks;

    public interface IRatingService
    {
        Task<ServiceResponse<double>> GetAverageRatingAsync(int movieId);

        Task<ServiceResponse<double>> RateMovieAsync(RatingDto rating);
    }
}
