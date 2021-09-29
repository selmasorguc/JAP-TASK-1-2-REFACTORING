namespace MovieApp.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using MovieApp.Database;
    using System.Threading.Tasks;

    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _context;

        public RatingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
