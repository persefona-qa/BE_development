using MediatR;

namespace NDubko.Application.Commands.Authors;

public class DeleteAuthorCommand : IRequest
{
    public int Id { get; set; }
}
