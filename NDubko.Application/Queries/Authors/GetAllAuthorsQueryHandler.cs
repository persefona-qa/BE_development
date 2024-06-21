using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Queries.Authors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
        {
            return await authorRepository.GetAll(cancellationToken);
        }
    }
}