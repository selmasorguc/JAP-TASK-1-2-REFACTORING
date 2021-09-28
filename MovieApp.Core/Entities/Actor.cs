namespace MovieApp.Core.Entities
{
    using System.Collections.Generic;

    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Media> Media { get; set; }
    }
}
