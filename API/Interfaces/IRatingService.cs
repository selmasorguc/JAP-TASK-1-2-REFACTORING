using System.Threading.Tasks;
using API.DTOs;
using API.Entity;

namespace API.Interfaces
{
    public interface IRatingService
    {
        Task<ServiceResponse<double>> GetAverageRatingAsync(int movieId);
        Task<ServiceResponse<double>> RateMovieAsync(RatingDto rating);
    }
}