using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Author.Commands
{
    public class CreateAuthorCommand : IRequest<WebApi.Models.Author>
    {
        public string FirstName { get; set; }  = String.Empty;
        public string LastName { get; set; }  = String.Empty;

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, WebApi.Models.Author>
        {
            private readonly IAuthorRepository _authorRepository;

            public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<WebApi.Models.Author> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
            {
                var author = new WebApi.Models.Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                };

                return await _authorRepository.CreateAuthor(author);
            }
        }
    }
}
