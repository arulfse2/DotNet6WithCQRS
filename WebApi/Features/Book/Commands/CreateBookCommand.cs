using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Book.Commands
{
    public class CreateBookCommand : IRequest<WebApi.Models.Book>
    {
        public string Title { get; set; }  = String.Empty;
        public string AuthorId { get; set; } = String.Empty;

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, WebApi.Models.Book>
        {
            private readonly IBookRepository _bookRepository;

            public CreateBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<WebApi.Models.Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
            {
                var book = new WebApi.Models.Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = command.Title,
                    AuthorId = command.AuthorId,
                };

                return await _bookRepository.CreateBook(book);
            }
        }
    }
}
