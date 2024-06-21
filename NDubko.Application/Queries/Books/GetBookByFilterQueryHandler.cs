using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Queries.Books;

public class GetBookByFilterQueryHandler : IRequestHandler<GetBookByFilterQuery, Book>
{
    private readonly IBookRepository bookRepository;

    public GetBookByFilterQueryHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<Book> Handle(GetBookByFilterQuery query, CancellationToken cancellationToken)
    {
        return await this.bookRepository.GetByFilter(query.Title, query.Publisher, cancellationToken);
    }
}