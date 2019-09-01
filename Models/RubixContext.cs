using Microsoft.EntityFrameworkCore;

namespace rubix.Models
{
  public class RubixContext : DbContext
  {
    public RubixContext(DbContextOptions<ResourceContext> options) : base(options) { }

    public DbSet<RubixUser> RubixUsers { get; set; }
  }
}