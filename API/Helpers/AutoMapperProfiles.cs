namespace API.Helpers
{
    using API.DTOs;
    using API.Entity;
    using AutoMapper;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Media, MediaDto>();
            CreateMap<MediaDto, Media>();
            CreateMap<Actor, ActorDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<AddTicketDto, Ticket>();
            CreateMap<Screening, ScreeningDto>();
            CreateMap<AddScreeningDto, Screening>();
        }
    }
}
