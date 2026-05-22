using User.Domain.Entity;

namespace User.Application.Interface;

public interface IRefreshTokenRepository
{
    Task<RefreshToken> Create (RefreshToken refreshToken);
    Task<RefreshToken?> GetByToken(string token);
    Task Remove(RefreshToken refreshToken);
}