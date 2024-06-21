using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Queries.Books;

public class GetBookByFilterQuery : IRequest<Book>
{
    public string Title { get; set; }

    public string Publisher { get; set; }
}