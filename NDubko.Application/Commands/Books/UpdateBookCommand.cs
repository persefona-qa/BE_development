using MediatR;

namespace NDubko.Application.Commands.Books;

public class UpdateBookCommand : IRequest
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Publisher { get; set; }
}
