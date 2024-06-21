using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDubko.Api.Requests;
using NDubko.Api.ViewModels;
using NDubko.Application.Commands.Books;
using NDubko.Application.Queries.Books;

namespace NDubko.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IMediator mediator;

    public BooksController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var command = this.mapper.Map<CreateBookCommand>(request);
        var result = await this.mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteBookCommand { Id = id });
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBookRequest request)
    {
        var command = this.mapper.Map<UpdateBookCommand>(request);
        await mediator.Send(command);

        return Ok(); ;
    }

    [HttpGet("{bookId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int bookId, CancellationToken cancellationToken)
    {
        var query = new GetBookByIdQuery { Id = bookId };
        var book = await mediator.Send(query, cancellationToken);
        if (book is null)
        {
            return NotFound();
        }

        var viewModel = this.mapper.Map<BookViewModel>(book);
        return Ok(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] GetBookByFilterRequest request, CancellationToken cancellationToken)
    {
        var query = this.mapper.Map<GetBookByFilterQuery>(request);
        var book = await mediator.Send(query, cancellationToken);
        if (book is null)
        {
            return NotFound();
        }

        var viewModel = this.mapper.Map<BookViewModel>(book);
        return Ok(viewModel);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var authors = await mediator.Send(new GetAllBooksQuery(), cancellationToken);
        var viewModel = this.mapper.Map<IEnumerable<BookViewModel>>(authors);

        return Ok(viewModel);
    }
}
