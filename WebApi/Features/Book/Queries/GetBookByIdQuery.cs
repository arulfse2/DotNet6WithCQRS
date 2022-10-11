using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Book.Queries
{
    public class GetBookByIdQuery : IRequest<WebApi.Models.Book>
    {
        public string Id { get; set; } = Guid.Empty.ToString();

        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, WebApi.Models.Book>
        {
            private readonly IBookRepository _bookRepository;

            public GetBookByIdQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<WebApi.Models.Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
            {
                return await _bookRepository.GetBookById(query.Id);
            }
        }
    }
}
