using User.Application.DTOs;

namespace User.Application.Interface;

public interface IUserService
{
    Task<UserResponseDto> Register(RegisterDto dto);
    Task<UserResponseDto> Login(LoginDto dto);
    Task<UserResponseDto> GetById(int id);
    Task Logout(string refreshToken);
}