using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Queries.Books;

public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
{
}