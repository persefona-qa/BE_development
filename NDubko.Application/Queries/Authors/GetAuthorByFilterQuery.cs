using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Queries.Authors;

public class GetAuthorByFilterQuery : IRequest<Author>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}
