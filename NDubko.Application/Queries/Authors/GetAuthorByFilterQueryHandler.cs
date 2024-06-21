using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Queries.Authors;

public class GetAuthorByFilterQueryHandler : IRequestHandler<GetAuthorByFilterQuery, Author>
{
    private readonly IAuthorRepository authorRepository;

    public GetAuthorByFilterQueryHandler(IAuthorRepository authorRepository)
    {
        this.authorRepository = authorRepository;
    }

    public async Task<Author> Handle(GetAuthorByFilterQuery query, CancellationToken cancellationToken)
    {
        return await this.authorRepository.GetByFilter(query.FirstName, query.LastName, cancellationToken);
    }
}