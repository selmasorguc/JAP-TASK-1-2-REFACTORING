using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Database;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
    }
}
