using WebApi.Models;

namespace WebApi.Repository
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetBooks();
        public Task<Book> GetBookById(string bookId);
        public Task<List<Book>> GetBooksByAuthorId(string authorId);
        public Task<Book> CreateBook(Book book);
        public Task<int> UpdateBook(Book book);
        public Task<int> DeleteBook(Book book);
    }
}