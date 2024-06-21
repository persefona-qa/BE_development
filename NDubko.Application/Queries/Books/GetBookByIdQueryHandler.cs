using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Queries.Books;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IBookRepository bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        return await this.bookRepository.GetById(query.Id, cancellationToken);
    }
}