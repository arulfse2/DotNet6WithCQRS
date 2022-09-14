namespace WebApi.Models;
public class Company : BaseEntity
{
    public Company()
    {
        Employees = new HashSet<Employee>();
    }

    public string Name { get; set; } = "";
    public string EstablishedYear { get; set; } = "";
    //public ICollection<CompanyEmployee> Employee { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }  = null!;
}