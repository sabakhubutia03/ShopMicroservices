using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Commands.LoginUser;
using User.Application.Commands.LogoutUser;
using User.Application.Commands.RegisterUser;
using User.Application.Queries.GetUserById;

namespace UserService.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("Logout")]
    public async Task<ActionResult> Logout(LogoutUserCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
