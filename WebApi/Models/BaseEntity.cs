namespace WebApi.Models;
public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string UpdatedBy { get; set; } = "ADMIN";
    public string AddedBy { get; set; } = "ADMIN";
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public int Status { get; set; } = 1;
}