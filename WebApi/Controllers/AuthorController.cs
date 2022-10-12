using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Author.Commands;
using WebApi.Features.Author.Queries;
using AutoMapper;
using WebApi.ViewModels;
using MediatR;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(ILogger<AuthorController> logger,
    IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet, Route("GetAuthors"), ProducesResponseType(typeof(IEnumerable<AuthorVM>), StatusCodes.Status200OK, "application/json")]
    public async Task<IEnumerable<AuthorVM>> Get()
    {
        var result = await _mediator.Send(new GetAllAuthorsQuery());
        return _mapper.Map<IList<AuthorVM>>(result);
    }
    [HttpGet, Route("GetAuthorById"), ProducesResponseType(typeof(AuthorVM), StatusCodes.Status200OK, "application/json")]
    public async Task<AuthorVM> Details([FromQuery] string id)
    {
        var result = await _mediator.Send(new GetAuthorByIdQuery() { Id = id });
        return _mapper.Map<AuthorVM>(result);
    }
    [HttpPost, Route("AddAuthor")]
    public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpPut, Route("UpdateAuthor")]
    public async Task<IActionResult> Edit([FromQuery] string id, [FromBody] UpdateAuthorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return Ok(await _mediator.Send(command));
    }

    [HttpDelete, Route("DeleteAuthor")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        return Ok(await _mediator.Send(new DeleteAuthorCommand() { Id = id }));
    }
}
