using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Commands.Books;

internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = command.Title,
            Publisher = command.Publisher,
            AuthorId = command.AuthorId
        };

        var id = await this.bookRepository.CreateAsync(book, cancellationToken);
        return id;
    }
}
