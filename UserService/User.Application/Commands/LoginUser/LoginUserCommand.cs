using MediatR;
using User.Application.DTOs;

namespace User.Application.Commands.LoginUser;

public record LoginUserCommand 
    (string Email, string Password) : IRequest<UserResponseDto>;