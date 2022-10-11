using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Book.Queries
{
    public class GetBooksByAuthorIdQuery : IRequest<IList<WebApi.Models.Book>>
    {
        public string AuthorId { get; set; } = Guid.Empty.ToString();

        public class GetBooksByAuthorIdQueryHandler : IRequestHandler<GetBooksByAuthorIdQuery, IList<WebApi.Models.Book>>
        {
            private readonly IBookRepository _bookRepository;

            public GetBooksByAuthorIdQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<IList<WebApi.Models.Book>> Handle(GetBooksByAuthorIdQuery query, CancellationToken cancellationToken)
            {
                return await _bookRepository.GetBooksByAuthorId(query.AuthorId);
            }
        }
    }
}
