using User.Application.DTOs;
using User.Application.Interface;

namespace User.Application.Service;

public class UserService : IUserService
{ 
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<UserResponseDto> Register(RegisterDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto> Login(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto> GetById(int id)
    {
        throw new NotImplementedException();
    }
}