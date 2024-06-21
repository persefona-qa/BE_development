using MediatR;
using Microsoft.AspNetCore.Mvc;
using NDubko.Application.Commands.Login;
using NDubko.Domain;

namespace NDubko.Api.Controllers;

/// <summary>
/// Task for #6 Create Authentication and Authorization method(Bearer token / JWT)
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IMediator mediator;

    public LoginController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        var loginCommand = new LoginCommand
        {
            User = user
        };

        var jwtToken = await this.mediator.Send(loginCommand);
        if (jwtToken == null)
        {
            return Unauthorized();
        }

        return Ok(jwtToken);
    }
}
