using Microsoft.EntityFrameworkCore;

namespace API.Entity.StoredProceduresEntites
{
 
    public class Top10Item
    {
        public int MediaId { get; set; }
        public string MediaTitle { get; set; }
        public double AverageRating { get; set; }
        public int TotalRatings { get; set; }
    }
}