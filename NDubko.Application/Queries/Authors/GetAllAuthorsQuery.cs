using MediatR;
using NDubko.Domain;

namespace NDubko.Application.Queries.Authors;

public class GetAllAuthorsQuery : IRequest<IEnumerable<Author>>
{
}
