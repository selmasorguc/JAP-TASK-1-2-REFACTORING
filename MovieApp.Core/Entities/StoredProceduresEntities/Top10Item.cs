namespace MovieApp.Core.Entities.StoredProceduresEntities
{

    public class Top10Item
    {
        public int MediaId { get; set; }
        public string MediaTitle { get; set; }
        public double AverageRating { get; set; }
        public int TotalRatings { get; set; }
    }
}