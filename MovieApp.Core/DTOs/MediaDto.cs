namespace MovieApp.Core.DTOs
{
    using MovieApp.Core.DTOs.ScreeningDtos;
    using MovieApp.Core.Entities;
    using System;
    using System.Collections.Generic;

    public class MediaDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string CoverUrl { get; set; }

        public MediaType MediaType { get; set; }

        public List<ActorDto> Cast { get; set; }

        public List<RatingDto> Ratings { get; set; }

        public List<ScreeningDto> Screenings { get; set; }
    }
}
