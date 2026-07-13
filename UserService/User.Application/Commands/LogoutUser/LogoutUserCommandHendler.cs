using MediatR;
using User.Application.Interface;
using User.Domein.Exceptions;

namespace User.Application.Commands.LogoutUser;

public class LogoutUserCommandHendler :IRequestHandler<LogoutUserCommand ,Unit>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LogoutUserCommandHendler(IRefreshTokenRepository refreshTokenRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
    }
    public  async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var token = await _refreshTokenRepository.GetByToken(request.RefreshToken);
        if (token == null)
        {
            throw new ApiException(
                "Token not found",
                "NotFound",
                404,
                "Token not found",
                "USER_LOAD_FAILED"
            );
        }
        await _refreshTokenRepository.Remove(token);
        
        return Unit.Value;
    }
}