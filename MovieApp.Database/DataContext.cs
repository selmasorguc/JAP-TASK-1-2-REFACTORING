namespace MovieApp.Database
{
    using Microsoft.EntityFrameworkCore;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Entities.StoredProceduresEntities;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Stored procedures models
            modelBuilder.Entity<Top10Item>().HasNoKey();
            modelBuilder.Entity<TopScreened>().HasNoKey();
            modelBuilder.Entity<TopSold>().HasNoKey();
        }

        public DbSet<Media> Media { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        public DbSet<Top10Item> TopRatedMovies { get; set; }

        public DbSet<TopScreened> TopScreenedMovies { get; set; }

        public DbSet<TopSold> TopSoldMovies { get; set; }
    }
}
