using MediatR;
using User.Application.DTOs;
using User.Application.Interface;
using User.Domein.Exceptions;

namespace User.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery , UserResponseDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var getUser = await _userRepository.GetById(request.Id);
        if (getUser == null)
        {
            throw new ApiException(
                $"User not found Id - {request.Id}",
                "NotFound",
                404,
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