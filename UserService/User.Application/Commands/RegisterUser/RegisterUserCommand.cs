using MediatR;
using User.Application.DTOs;

namespace User.Application.Commands.RegisterUser;

public record RegisterUserCommand (
    string Username,
    string Email,
    string Password): IRequest<UserResponseDto>;