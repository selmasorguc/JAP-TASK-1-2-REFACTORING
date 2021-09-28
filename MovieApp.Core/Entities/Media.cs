namespace MovieApp.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Actor> Cast { get; set; }
        public List<Screening> Screenings { get; set; }
        public MediaType MediaType { get; set; } = MediaType.Movie;
    }
}
