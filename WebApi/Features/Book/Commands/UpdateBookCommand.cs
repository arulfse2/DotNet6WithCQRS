using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Book.Commands
{
    public class UpdateBookCommand : IRequest<int>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }  = String.Empty;
        public string AuthorId { get; set; }  = String.Empty;

        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
        {
            private readonly IBookRepository _bookRepository;

            public UpdateBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetBookById(command.Id);
                if (book == null)
                    return default;

                book.Title = command.Title;
                book.AuthorId = command.AuthorId;

                return await _bookRepository.UpdateBook(book);
            }
        }
    }
}
