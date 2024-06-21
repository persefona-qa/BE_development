using MediatR;
using NDubko.Database.Repositories;
using NDubko.Domain;

namespace NDubko.Application.Commands.Authors;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IAuthorRepository authorRepository;

    public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        this.authorRepository = authorRepository;
    }
    public async Task Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = new Author 
        { 
            Id = command.Id, 
            FirstName = command.FirstName, 
            LastName = command.LastName 
        };
        await this.authorRepository.UpdateAsync(author, cancellationToken);
    }
}
