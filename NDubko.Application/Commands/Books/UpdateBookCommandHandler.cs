using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Commands.Books
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = command.Id,
                Title = command.Title,
                Publisher = command.Publisher,
            };

            await this.bookRepository.UpdateAsync(book, cancellationToken);
        }
    }
}
