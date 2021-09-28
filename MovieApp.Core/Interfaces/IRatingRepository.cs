using MovieApp.Core.Entities;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface IRatingRepository
    {
        Task<bool> AddRating(Rating rating);

    }
}