using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Commands.Login;

public class LoginCommand : IRequest<string>
{
    public User User { get; set; }
}
