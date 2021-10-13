using Microsoft.EntityFrameworkCore;

namespace TvShow.Models
{
  public class TvShowContext : DbContext
  {
    public DbSet<Show> Shows {get; set;}
    public DbSet<Genre> Genres {get; set;}
    public DbSet<Network> Networks {get; set;}
    public DbSet<ShowGenres> ShowGenres {get; set;}
    public DbSet<ShowNetworks> ShowNetworks {get; set;}

    public TvShowContext(DbContextOptions options) : base(options) {}

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}