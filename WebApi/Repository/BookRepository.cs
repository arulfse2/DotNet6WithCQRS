using WebApi.Models;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly CqrsDbContext _context;

        public BookRepository(CqrsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetBooks()
        {
            var list = _context.Books
                     .Include(a => a.Author)
                     .ToListAsync();
            return await list;
        }

        public async Task<Book> GetBookById(string boookId)
        {
            return await _context.Books
                .Include(a => a.Author)
                .FirstOrDefaultAsync(x => x.Id == boookId);
        }

        public async Task<List<Book>> GetBooksByAuthorId(string authorId)
        {
            return await _context.Books
                .Include(a => a.Author)
                .Where(x => x.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Book> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<int> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync();
        }
    }
}