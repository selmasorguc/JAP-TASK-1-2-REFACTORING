namespace MovieApp.Mapper
{
    using AutoMapper;
    using MovieApp.Core.DTOs;
    using MovieApp.Core.DTOs.ScreeningDtos;
    using MovieApp.Core.DTOs.TicketDtos;
    using MovieApp.Core.Entities;

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
