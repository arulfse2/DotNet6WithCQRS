using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Book.Queries
{
    public class GetAllBooksQuery : IRequest<IList<WebApi.Models.Book>>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IList<WebApi.Models.Book>>
        {
            private readonly IBookRepository _bookRepository;

            public GetAllBooksQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<IList<WebApi.Models.Book>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
            {
                return await _bookRepository.GetBooks();
            }
        }
    }
}