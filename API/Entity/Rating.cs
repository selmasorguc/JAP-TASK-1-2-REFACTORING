namespace API.Entity
{
    public class Rating
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public int MediaId { get; set; }

        public Media Media { get; set; }
    }
}
