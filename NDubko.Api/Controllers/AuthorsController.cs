using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NDubko.Application.Commands.Authors;
using NDubko.Api.Requests;
using NDubko.Application.Queries.Authors;
using NDubko.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace NDubko.Api.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IMediator mediator;

    public AuthorsController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorRequest request, CancellationToken cancellationToken)
    {
        var command = this.mapper.Map<CreateAuthorCommand>(request);
        var result = await this.mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteAuthorCommand { Id = id }, cancellationToken);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAuthorRequest request, CancellationToken cancellationToken)
    {
        var command = this.mapper.Map<UpdateAuthorCommand>(request);
        await mediator.Send(command, cancellationToken);

        return Ok(); ;
    }

    [HttpGet("{authorId:int}")]
    public async Task<IActionResult> GetById([FromRoute]int authorId, CancellationToken cancellationToken)
    {
        var query = new GetAuthorByIdQuery { Id = authorId };
        var author = await mediator.Send(query, cancellationToken);
        if (author is null)
        {
            return NotFound();
        }

        var viewModel = this.mapper.Map<AuthorViewModel>(author);
        return Ok(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] GetAuthorByFilterRequest request, CancellationToken cancellationToken)
    {
        var query = this.mapper.Map<GetAuthorByFilterQuery>(request);
        var author = await mediator.Send(query, cancellationToken);
        if (author is null)
        {
            return NotFound();
        }

        var viewModel = this.mapper.Map<AuthorViewModel>(author);
        return Ok(viewModel);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var authors = await mediator.Send(new GetAllAuthorsQuery(), cancellationToken);
        var viewModel = this.mapper.Map<IEnumerable<AuthorViewModel>>(authors);

        return Ok(viewModel);
    }
}
