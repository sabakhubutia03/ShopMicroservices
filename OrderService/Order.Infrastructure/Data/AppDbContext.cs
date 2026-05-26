using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Domain.Entities.Order> Orders { get; set; }
}