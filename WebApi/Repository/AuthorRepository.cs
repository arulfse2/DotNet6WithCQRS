using WebApi.Models;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CqrsDbContext _context;

        public AuthorRepository(CqrsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> GetAuthors()
        {
            var list = _context.Authors
                     .ToListAsync();
            return await list;
        }

        public async Task<Author?> GetAuthorById(string authorId)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(x => x.Id == authorId);
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<int> UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync();
        }
    }
}