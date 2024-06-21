using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Queries.Authors;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
{
    private readonly IAuthorRepository authorRepository;

    public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
    {
        this.authorRepository = authorRepository;
    }

    public async Task<Author> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
    {
        return await this.authorRepository.GetById(query.Id, cancellationToken);
    }
}
