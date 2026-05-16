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
}