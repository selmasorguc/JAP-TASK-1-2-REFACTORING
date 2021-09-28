using MovieApp.Core.Entities;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> AddTicket(Ticket ticket);
    }
}
