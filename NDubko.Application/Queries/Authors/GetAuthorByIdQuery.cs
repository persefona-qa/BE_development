using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Queries.Authors;

public class GetAuthorByIdQuery : IRequest<Author>
{
    public int Id { get; set; }
}
