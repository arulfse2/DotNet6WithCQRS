using WebApi.Repository;
using MediatR;

namespace WebApi.Features.Author.Commands
{
    public class DeleteAuthorCommand : IRequest<int>
    {
        public string Id { get; set; } = Guid.Empty.ToString();

        public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, int>
        {
            private readonly IAuthorRepository _authorRepository;

            public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<int> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetAuthorById(command.Id);
                if (author == null)
                    return default;

                return await _authorRepository.DeleteAuthor(author);
            }
        }
    }
}
