using Microsoft.EntityFrameworkCore;
using User.Application.Interface;
using User.Domain.Entity;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repository;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AppDbContext _dbContext;

    public RefreshTokenRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<RefreshToken> Create(RefreshToken refreshToken)
    {
        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();
        return refreshToken;
    }

    public async Task<RefreshToken?> GetByToken(string token)
    {
        return await _dbContext.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == token);
    }

    public async Task Remove(RefreshToken refreshToken)
    {
        _dbContext.RefreshTokens.Remove(refreshToken);
        await _dbContext.SaveChangesAsync();
    }
}