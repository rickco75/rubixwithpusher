using Microsoft.EntityFrameworkCore;

namespace rubix.Models
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public DbSet<AspNetUser> AspNetUsers { get; set; }
    public DbSet<AspNetRole> AspNetRoles { get; set; }
    public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    // public DbSet<UserDb> UserDb { get; set; }
  }
}