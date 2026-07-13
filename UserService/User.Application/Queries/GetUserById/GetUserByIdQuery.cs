using MediatR;
using User.Application.DTOs;

namespace User.Application.Queries.GetUserById;

public record GetUserByIdQuery (int Id): IRequest<UserResponseDto>;