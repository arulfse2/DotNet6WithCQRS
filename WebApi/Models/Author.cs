
namespace WebApi.Models
{
    public class Author
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; }  = String.Empty;
        public List<Book> Books { get; set; } = null!;
    }
}