using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Commands.RegisterUser;
using User.Application.DTOs;
using User.Application.Interface;

namespace UserService.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMediator _mediator;

    public UserController(IUserService userService, IMediator mediator)
    {
        _userService = userService;
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
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _userService.Login(dto);
        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _userService.GetById(id);
        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout(string refreshToken)
    {
        await _userService.Logout(refreshToken);
        return Ok("Logged out Successfully");
    }
}
