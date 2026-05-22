using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<Domain.Entity.User> Users { get; set; }
    public DbSet<Domain.Entity.RefreshToken> RefreshTokens { get; set; }
}