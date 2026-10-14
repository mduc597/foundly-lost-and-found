using Foundly.Sprint1.Domain;
using Microsoft.EntityFrameworkCore;
namespace Foundly.Sprint1.Data;
public class SprintDb(DbContextOptions<SprintDb> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<CampusLocation> Locations => Set<CampusLocation>();
    public DbSet<ItemReport> Reports => Set<ItemReport>();
    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Student>().HasIndex(x => x.Email).IsUnique();
        b.Entity<ItemReport>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        b.Entity<ItemReport>().HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        b.Entity<ItemReport>().HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId).OnDelete(DeleteBehavior.Restrict);
        b.Entity<ItemReport>().HasIndex(x => new { x.Status, x.CreatedAt });
        b.Entity<ItemReport>().HasIndex(x => new { x.CategoryId, x.LocationId, x.CreatedAt });
    }
}
