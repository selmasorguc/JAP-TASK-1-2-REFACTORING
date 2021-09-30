using MovieApp.Core.Entities;

namespace MovieApp.Core.DTOs
{
    public class MediaParams : Pagination
    {
        public MediaType? MediaType { get; set; }
        public string SearchQuery { get; set; }
    }
}
