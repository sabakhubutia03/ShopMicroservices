using MediatR;
using User.Application.DTOs;
using User.Application.Interface;
using User.Domain.Entity;
using User.Domein.Exceptions;

namespace User.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository, IJwtService jwtService, IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
    }
    public async Task<UserResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var checkEmail = await _userRepository.GetByEmail(request.Email);
        if (checkEmail != null)
        {
            throw new ApiException(
                "Email already exists!",
                "Conflict",
                409,
                "Email already exists!",
                "Email already exists!"
                );
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new Domain.Entity.User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow
        };

        var createUser = await _userRepository.Create(user);
        if (createUser == null)
        {
            throw new ApiException(
                "Failed to create user",
                "Bad Request",
                400,
                "Failed to create user",
                "USER_CREATE_FAILED"
            );
        }

        var refeshToken = new RefreshToken
        {
            Token = _jwtService.GenerateRefreshToken(),
            UserId = createUser.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        await _refreshTokenRepository.Create(refeshToken);

        return new UserResponseDto
        {
            Id = createUser.Id,
            UserName = createUser.Username,
            Email = createUser.Email,
            Created = createUser.CreatedAt,
            AccessToken = _jwtService.GenerateAccessToken(createUser), 
            RefreshToken = refeshToken.Token
        };
    }
}