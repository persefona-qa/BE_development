using MediatR;
using NDubko.Database.Repositories;

namespace NDubko.Application.Commands.Books;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        await this.bookRepository.DeleteAsync(command.Id, cancellationToken);
    }
}
