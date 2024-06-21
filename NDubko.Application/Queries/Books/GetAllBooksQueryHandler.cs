using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            return await bookRepository.GetAll(cancellationToken);
        }
    }
}