using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Book.Commands
{
    public class DeleteBookCommand : IRequest<int>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
        {
            private readonly IBookRepository _bookRepository;

            public DeleteBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<int> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetBookById(command.Id);
                if (book == null)
                    return default;

                return await _bookRepository.DeleteBook(book);
            }
        }
    }
}
