using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Author.Commands
{
    public class UpdateAuthorCommand : IRequest<int>
    {
        public string Id { get; set; } = Guid.Empty.ToString();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;

        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
        {
            private readonly IAuthorRepository _authorRepository;

            public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<int> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetAuthorById(command.Id);
                if (author == null)
                    return default;

                author.FirstName = command.FirstName;
                author.LastName = command.LastName;

                return await _authorRepository.UpdateAuthor(author);
            }
        }
    }
}
