namespace API.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.Core.DTOs.TicketDtos;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Buying a new ticket functionality - adds new ticket to the DB, updates screening and the media
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>Bought ticket added to the DB</returns>
        [HttpPost("buy")]
        public async Task<ActionResult<ServiceResponse<AddTicketDto>>> BuyTicket(TicketDto ticket)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var serviceResponse = await _ticketService.BuyTicket(ticket, username);

            if (serviceResponse.Data == null) return NotFound(serviceResponse);

            return Ok(serviceResponse);
        }
    }
}
