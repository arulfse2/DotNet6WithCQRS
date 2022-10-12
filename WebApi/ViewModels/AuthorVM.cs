namespace WebApi.ViewModels
{
    public class AuthorVM
    {
        public string Id { get; set; } = Guid.Empty.ToString();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; }  = String.Empty;
        public string MiddleName { get; set; }  = String.Empty;
    }
}