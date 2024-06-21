using NDubko.Domain;
using NDubko.Application.Options;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace NDubko.Application.Commands.Login;

/// <summary>
/// Task for #6
/// Create Authentication and Authorization method(Bearer token / JWT)
/// </summary>
public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly List<User> users = new()
    {
        new("user1@ndubko.com", "12345"),
        new("user2@ndubko.com", "67891")
    };

    private readonly AuthOptions authOptions;

    //Task for #8 Configuration Options Pattern
    public LoginCommandHandler(IOptions<AuthOptions> authOptions)
    {
        this.authOptions = authOptions.Value;
    }

    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = users.FirstOrDefault(p => p.UserName == request.User.UserName && p.Password == request.User.Password);

        if (user is null)
        {
            return Task.FromResult((string)null);
        }

        var claims = new List<Claim> { new (ClaimTypes.Name, user.UserName) };

        var jwt = new JwtSecurityToken(
            issuer: authOptions.Issuer,
            audience: authOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Task.FromResult(encodedJwt);
    }
}
