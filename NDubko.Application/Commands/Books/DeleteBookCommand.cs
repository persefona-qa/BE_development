using MediatR;

namespace NDubko.Application.Commands.Books;

public class DeleteBookCommand : IRequest
{
    public int Id { get; set; }
}
