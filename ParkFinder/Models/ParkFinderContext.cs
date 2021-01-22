using Microsoft.EntityFrameworkCore;

namespace ParkFinder.Models
{
    public class ParkFinderContext : DbContext
    {
        public ParkFinderContext(DbContextOptions<ParkFinderContext> options):base(options)
        {
        }
        public DbSet<Park> Parks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Park>()
                .HasData(
                    new Park { ParkId = 1, ParkType = "National Park", ParkName = "Crater Lake", City = "Crater Lake", State = "OR", Status = "Open", Website = "https://www.nps.gov/crla/index.htm"},
                    new Park { ParkId = 2, ParkType = "National Reserve", ParkName = "New Jersey Pinelands", City = "Batsto", State = "NJ", Status = "Open", Website = "https://www.nps.gov/pine/index.htm"}
                );
        }
    }
}