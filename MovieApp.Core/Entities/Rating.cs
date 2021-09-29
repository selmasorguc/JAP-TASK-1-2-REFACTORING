using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(0, 5)]
        public double Value { get; set; } = 0;

        public int MediaId { get; set; }

        public Media Media { get; set; }
    }
}
