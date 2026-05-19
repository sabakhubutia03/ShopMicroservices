using Microsoft.EntityFrameworkCore;
using Product.Domain.Entity;

namespace Product.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    } 
    
    public DbSet<Domain.Entity.Product> Products { get; set; }
    public DbSet<Category> Categories  { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entity.Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }
}