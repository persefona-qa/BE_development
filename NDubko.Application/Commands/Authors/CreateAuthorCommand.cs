using MediatR;

namespace NDubko.Application.Commands.Authors;

public class CreateAuthorCommand : IRequest<int>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}