using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Queries.Books;

public class GetBookByIdQuery : IRequest<Book>
{
    public int Id { get; set; }
}
