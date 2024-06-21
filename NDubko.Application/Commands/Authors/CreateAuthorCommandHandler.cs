using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;


namespace NDubko.Application.Commands.Authors;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository authorRepository;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
    { 
        this.authorRepository = authorRepository;
    }

    public async Task<int> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = new Author() { FirstName = command.FirstName, LastName = command.LastName };
        await authorRepository.CreateAsync(author, cancellationToken);

        return author.Id;
    }
}
