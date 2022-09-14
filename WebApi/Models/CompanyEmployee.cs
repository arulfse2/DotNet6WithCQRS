namespace WebApi.Models;
public class CompanyEmployee
{
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}