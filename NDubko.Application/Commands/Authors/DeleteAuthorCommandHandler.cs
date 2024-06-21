using MediatR;
using NDubko.Database.Repositories;

namespace NDubko.Application.Commands.Authors;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly IAuthorRepository authorRepository;

    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        this.authorRepository = authorRepository;
    }
    public async Task Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
    {
        await this.authorRepository.DeleteAsync(command.Id, cancellationToken);
    }
}
