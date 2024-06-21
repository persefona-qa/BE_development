using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDubko.Application.Commands.Books;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; }

    public string Publisher { get; set; }

    public int AuthorId { get; set; }
}
