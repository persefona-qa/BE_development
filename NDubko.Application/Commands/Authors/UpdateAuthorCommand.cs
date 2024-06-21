using MediatR;

namespace NDubko.Application.Commands.Authors;

public class UpdateAuthorCommand : IRequest
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}