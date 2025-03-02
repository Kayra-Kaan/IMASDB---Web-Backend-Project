using IMASDB.Models;
using Microsoft.EntityFrameworkCore;

namespace IMASDB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, MovieName = "The Last Case", Duration = 145 },
                new Movie { MovieId = 2, MovieName = "Death Night", Duration = 119 });

            modelBuilder.Entity<Show>().HasData(
                new Show { ShowId = 1, ShowName = "High School Life", SeasonCount = 4, EpisodeCount = 80 },
                new Show { ShowId = 2, ShowName = "Depression", SeasonCount = 3, EpisodeCount = 12 },
                new Show { ShowId = 3, ShowName = "Opposites", SeasonCount = 1, EpisodeCount = 8 });
        }
    }
}
