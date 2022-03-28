using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
  public class TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext> options)
    : base (options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Place>()
              .HasData(
                  new Place{ PlaceId = 1, City = "Seattle", State = "Washington", Country = "U.S.", Review = "AOK"},
                  new Place{ PlaceId = 2, City = "Portland", State = "Oregon", Country = "U.S.", Review = "Awesome"},
                  new Place{ PlaceId = 3, City = "San Francisco", State = "California", Country = "U.S.", Review = "Shaky"},
                  new Place{ PlaceId = 4, City = "Vancouver", State = "British Columbia", Country = "Canada", Review = "All right"},
                  new Place{ PlaceId = 5, City = "Bejing", Country = "China", Review = "Neato"}
              );
        }
    public DbSet<Place> Places { get; set; }
  }
}