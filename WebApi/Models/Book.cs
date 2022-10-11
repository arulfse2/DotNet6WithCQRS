
namespace WebApi.Models
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = String.Empty;
        public string AuthorId { get; set; } = String.Empty;
        public Author Author { get; set; } = null!;
    }
}