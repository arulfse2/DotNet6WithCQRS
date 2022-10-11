using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Book.Queries;
using WebApi.Features.Book.Commands;
using WebApi.Models;
using MediatR;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger,
    IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IEnumerable<Book>> Get()
    {
        return await _mediator.Send(new GetAllBooksQuery());
    }
    [HttpGet, Route("GetBookById")]
    public async Task<IActionResult> DetailsById([FromQuery] string id)
    {
        return Ok(await _mediator.Send(new GetBookByIdQuery() { Id = id }));
    }
    [HttpGet, Route("GetBookByAuthorId")]
    public async Task<IActionResult> DetailsByAuthorId([FromQuery] string authorId)
    {
        return Ok(await _mediator.Send(new GetBooksByAuthorIdQuery() { AuthorId = authorId }));
    }
    [HttpPost, Route("AddBook")]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpPost, Route("UpdateBook")]
    public async Task<IActionResult> Edit([FromQuery] string id, [FromBody] UpdateBookCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return Ok(await _mediator.Send(command));
    }

    [HttpGet, Route("DeleteBook")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        return Ok(await _mediator.Send(new DeleteBookCommand() { Id = id }));
    }
}
