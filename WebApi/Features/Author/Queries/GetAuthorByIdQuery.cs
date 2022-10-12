using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Author.Queries
{
    public class GetAuthorByIdQuery : IRequest<WebApi.Models.Author>
    {
        public string Id { get; set; } = String.Empty;

        public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, WebApi.Models.Author>
        {
            private readonly IAuthorRepository _authorRepository;

            public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<WebApi.Models.Author> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
            {
                return await _authorRepository.GetAuthorById(query.Id);
            }
        }
    }
}
