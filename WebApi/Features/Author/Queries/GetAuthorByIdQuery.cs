using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;
using MediatR;

namespace dotnetcqrs.Features.Author.Queries
{
    public class GetAuthorByIdQuery : IRequest<WebApi.Models.Author>
    {
        public string Id { get; set; }

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
