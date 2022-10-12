namespace WebApi.ViewModels
{
    public class BookVM
    {
        public string Id { get; set; } = Guid.Empty.ToString();
        public string Title { get; set; } = String.Empty;
        public string AuthorId { get; set; } = String.Empty;
    }
}