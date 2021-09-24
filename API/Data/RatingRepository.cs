using System.Threading.Tasks;
using API.Entity;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _context;
        public RatingRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.Entry(rating).State = EntityState.Modified;
            return SaveAllAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}