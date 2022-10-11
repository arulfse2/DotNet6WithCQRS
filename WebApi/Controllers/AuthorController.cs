using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Author.Commands;
using WebApi.Features.Author.Queries;
using WebApi.Models;
using MediatR;
using dotnetcqrs.Features.Author.Queries;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(ILogger<AuthorController> logger,
    IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet, Route("GetAuthors")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
    }
    [HttpGet, Route("GetAuthorById")]
    public async Task<IActionResult> Details([FromQuery] string id)
    {
        return Ok(await _mediator.Send(new GetAuthorByIdQuery() { Id = id }));
    }
    [HttpPost, Route("AddAuthor")]
    public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpPost, Route("UpdateAuthor")]
    public async Task<IActionResult> Edit([FromQuery] string id, [FromBody] UpdateAuthorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return Ok(await _mediator.Send(command));
    }

    [HttpGet, Route("DeleteAuthor")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        return Ok(await _mediator.Send(new DeleteAuthorCommand() { Id = id }));
    }
}
