using MediatR;
using User.Application.DTOs;
using User.Application.Interface;
using User.Domain.Entity;
using User.Domein.Exceptions;

namespace User.Application.Commands.LoginUser;

public class LoginUserCommandHendler : IRequestHandler<LoginUserCommand , UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IJwtService _jwtService;

    public LoginUserCommandHendler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _jwtService = jwtService;
    }
    
    public async Task<UserResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var checkEmail = await _userRepository.GetByEmail(request.Email);
        if (checkEmail == null)
        {
            throw new ApiException(
                "User not found",
                "NotFound",
                404,
                "User not found",
                "USER_LOGIN_FAILED"
            );
        }
        
        var checkPassword = BCrypt.Net.BCrypt.Verify(request.Password, checkEmail.PasswordHash);
        if (!checkPassword)
        {
            throw new ApiException(
                "Invalid password or email.",
                "Bad Request",
                400,
                "Invalid password or email.",
                "USER_LOGIN_FAILED"
            );
        }

        var refreshToken = new RefreshToken
        {
            Token = _jwtService.GenerateRefreshToken(),
            UserId = checkEmail.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };
        await _refreshTokenRepository.Create(refreshToken);
        
        return new UserResponseDto
        {
            Id = checkEmail.Id,
            UserName = checkEmail.Username,
            Email = checkEmail.Email,
            Created = checkEmail.CreatedAt,
            AccessToken = _jwtService.GenerateAccessToken(checkEmail),
            RefreshToken = refreshToken.Token
        };
    }
}