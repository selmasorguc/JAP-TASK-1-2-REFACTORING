using MovieApp.Core.Entities;

namespace MovieApp.Core.DTOs
{
    public class MediaParams
    {
        private const int MaxPageSize = 20;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public MediaType? MediaType { get; set; }

        public int PageSize { get => _pageSize; set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }

        //public string? SearchQuery { get; set; } =  null;
        public string SearchQuery { get; set; }
    }
}
