using User.Application.DTOs;
using User.Application.Interface;
using User.Domein.Exceptions;

namespace User.Application.Service;

public class UserService : IUserService
{ 
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponseDto> Register(RegisterDto dto)
    {
        var checkEmail = await _userRepository.GetByEmail(dto.Email);
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
        
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        
       var user = new Domain.Entity.User
        {
            Username = dto.UserName,
            Email = dto.Email,
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

        return new UserResponseDto
        {
            Id = createUser.Id,
            UserName = createUser.Username,
            Email = createUser.Email,
            Created = createUser.CreatedAt,
        };
    }

    public async Task<UserResponseDto> Login(LoginDto dto)
    {
        var checkEmail = await _userRepository.GetByEmail(dto.Email);
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
        
        var checkPassword = BCrypt.Net.BCrypt.Verify(dto.Password, checkEmail.PasswordHash);
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

        return new UserResponseDto
        {
            Id = checkEmail.Id,
            UserName = checkEmail.Username,
            Email = checkEmail.Email,
            Created = checkEmail.CreatedAt,
        };
    }

    public async Task<UserResponseDto> GetById(int id)
    {
        var getUser = await _userRepository.GetById(id);
        if (getUser == null)
        {
            throw new ApiException(
                $"User not found Id - {id}",
                "NotFound",
                400,
                "User not found",
                "USER_LOAD_FAILED"
            );
        }

        return new UserResponseDto
        {
            Id = getUser.Id,
            UserName = getUser.Username,
            Email = getUser.Email,
            Created = getUser.CreatedAt
        };
    }
}