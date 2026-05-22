namespace User.Application.Interface;

public interface IJwtService
{
    string GenerateAccessToken(Domain.Entity.User user);
    string GenerateRefreshToken();
}