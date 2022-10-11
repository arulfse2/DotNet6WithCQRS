using WebApi.Models;

namespace WebApi.Repository
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAuthors();
        public Task<Author?> GetAuthorById(string authorId);
        public Task<Author> CreateAuthor(Author author);
        public Task<int> UpdateAuthor(Author author);
        public Task<int> DeleteAuthor(Author author);
    }
}