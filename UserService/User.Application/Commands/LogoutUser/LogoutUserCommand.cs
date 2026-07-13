using MediatR;

namespace User.Application.Commands.LogoutUser;

public record LogoutUserCommand (string RefreshToken) : IRequest<Unit>;