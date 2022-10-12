using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Book.Queries;
using WebApi.Features.Book.Commands;
using WebApi.ViewModels;
using AutoMapper;
using MediatR;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger,
    IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetBooks"), ProducesResponseType(typeof(IEnumerable<BookVM>), StatusCodes.Status200OK, "application/json")]
    public async Task<IEnumerable<BookVM>> Get()
    {
        var result = await _mediator.Send(new GetAllBooksQuery());
        return _mapper.Map<IList<BookVM>>(result);
    }
    [HttpGet, Route("GetBookById"), ProducesResponseType(typeof(BookVM), StatusCodes.Status200OK, "application/json")]
    public async Task<BookVM> DetailsById([FromQuery] string id)
    {
        var result = await _mediator.Send(new GetBookByIdQuery() { Id = id });
        return _mapper.Map<BookVM>(result);
    }
    [HttpGet, Route("GetBookByAuthorId"), ProducesResponseType(typeof(IEnumerable<BookVM>), StatusCodes.Status200OK, "application/json")]
    public async Task<IEnumerable<BookVM>> DetailsByAuthorId([FromQuery] string authorId)
    {
        var result = await _mediator.Send(new GetBooksByAuthorIdQuery() { AuthorId = authorId });
        return _mapper.Map<IList<BookVM>>(result);
    }
    [HttpPost, Route("AddBook")]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpPut, Route("UpdateBook")]
    public async Task<IActionResult> Edit([FromQuery] string id, [FromBody] UpdateBookCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return Ok(await _mediator.Send(command));
    }

    [HttpDelete, Route("DeleteBook")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        return Ok(await _mediator.Send(new DeleteBookCommand() { Id = id }));
    }
}
