namespace MovieApp.Core.Services
{
    using AutoMapper;
    using MovieApp.Core.DTOs.TicketDtos;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;

        private readonly ITicketRepository _ticketRepository;

        private readonly IAuthRepository _authRepository;

        private readonly IMediaRepository _mediaRepository;

        private readonly IScreeningRepository _screeningRepository;

        public TicketService(ITicketRepository ticketRepository, IScreeningRepository screeningRepository,
            IMapper mapper, IAuthRepository authRepository, IMediaRepository mediaRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _authRepository = authRepository;
            _screeningRepository = screeningRepository;
            _mediaRepository = mediaRepository;
        }

        public async Task<ServiceResponse<AddTicketDto>> BuyTicket(TicketDto ticket, string username)
        {
            var serviceResponse = new ServiceResponse<AddTicketDto>();

            try
            {
                //Check if movie and user exist in the DB
                if (!(await _mediaRepository.MediaExists(ticket.MediaId)))
                    throw new ArgumentException("Movie id is not valid.");

                var user = await _authRepository.GetUserByUsernameAsync(username);

                var screening = await _screeningRepository.UpdateScreening(ticket.ScreeningId);

                if (screening.StartTime < DateTime.Today)
                    throw new ArgumentException(
                           "Cannot buy ticket for screening is in the past");

                var addTicket = new AddTicketDto
                {
                    Price = ticket.Price,
                    MediaId = ticket.MediaId,
                    UserId = user.Id,
                    ScreeningId = screening.Id
                };

                await _ticketRepository.AddTicket(_mapper.Map<Ticket>(addTicket));
                serviceResponse.Data = addTicket;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}
