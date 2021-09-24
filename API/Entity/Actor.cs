namespace API.Entity
{
    using System.Collections.Generic;

    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Media> Media { get; set; }
    }
}
