namespace MovieApp.Core.Entities.StoredProceduresEntities
{
    public class TopSold
    {
        public int MediaId { get; set; }
        public string MediaTitle { get; set; }
        public int TicketsSold { get; set; }
    }
}