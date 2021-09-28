using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Database;
using System;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly DataContext _context;
        public ScreeningRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Screening> GetScreening(int id)
        {
            return await _context.Screenings.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<Screening> UpdateScreening(int id)
        {
            var screening = await GetScreening(id);
            if (screening == null)
                throw new ArgumentException(
                       "Screening id is not valid. Are you sure this screening exists in the database?");

            if (screening.MaxSeatsNumber == 0)
                throw new ArgumentException(
                       "No available seats. Tickets sold out.");

            screening.MaxSeatsNumber -= 1;
            _context.Screenings.Update(screening);
            await _context.SaveChangesAsync();

            return screening;
        }
    }
}
