using Microsoft.EntityFrameworkCore;

namespace rubix.Models
{
  public class ResourceContext : DbContext
  {
    public ResourceContext(DbContextOptions<ResourceContext> options) : base(options) { }

    public DbSet<Resources> Resources { get; set; }
  }
}