using System.Threading.Tasks;
using API.DTOs;
using API.Entity;

namespace API.Interfaces
{
    public interface IRatingRepository
    {
        Task<bool> AddRating(Rating rating);
        Task<bool> SaveAllAsync();
    }
}