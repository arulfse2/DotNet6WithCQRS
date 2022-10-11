using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Author.Queries
{
    public class GetAllAuthorsQuery : IRequest<IList<WebApi.Models.Author>>
    {
        public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IList<WebApi.Models.Author>>
        {
            private readonly IAuthorRepository _authorRepository;

            public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<IList<WebApi.Models.Author>> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
            {
                return await _authorRepository.GetAuthors();
            }
        }
    }
}