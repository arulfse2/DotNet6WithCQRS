namespace WebApi.Models;

public class Employee : BaseEntity
{
    // public Employee()
    // {
    //     Company = new HashSet<CompanyEmployee>();
    // }

    public string EmployeeId { get; set; } = "";
    public string Name { get; set; } = "";
    public string JoiningYear { get; set; } = "";
    public string Designation { get; set; } = "";
    //public ICollection<CompanyEmployee> Company { get; set; }
    public Guid CompanyId { get; set; } = Guid.Empty;
    public virtual Company Company { get; set; } = null!;
}