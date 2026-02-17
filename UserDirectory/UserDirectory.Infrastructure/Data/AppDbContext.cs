using Microsoft.EntityFrameworkCore;
using UserDirectory.Api.Models;

namespace UserDirectory.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(u => u.Id);
            b.Property(u => u.Name).IsRequired().HasMaxLength(100);
            b.Property(u => u.Age).IsRequired();
            b.Property(u => u.City).IsRequired();
            b.Property(u => u.State).IsRequired();
            b.Property(u => u.Pincode).IsRequired().HasMaxLength(10);
        });
    }
}
