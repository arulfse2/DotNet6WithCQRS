using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var cid1 = Guid.NewGuid();
        var cid2 = Guid.NewGuid();
        var eid1 = Guid.NewGuid();
        var eid2 = Guid.NewGuid();
        var eid3 = Guid.NewGuid();

        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = cid1,
                Name = "Cognizant Technology Solutions",
                EstablishedYear = "1994"
            },
             new Company
             {
                 Id = cid2,
                 Name = "Wipro Ltd",
                 EstablishedYear = "1945"
             }
        );

        modelBuilder.Entity<Employee>().HasData(
           new Employee
           {
               Id = eid1,
               EmployeeId = "CTS1",
               CompanyId = cid1,
               Name = "Arulprakash Subramanian",
               JoiningYear = "2016",
               Designation = "Senior Software Engineer",
           },
            new Employee
            {
                Id = eid2,
                EmployeeId = "CTS2",
                CompanyId = cid1,
                Name = "Saravanan",
                JoiningYear = "2016",
                Designation = "Senior Software Engineer",
            },
            new Employee
            {
                Id = eid3,
                EmployeeId = "WIP1",
                CompanyId = cid2,
                Name = "Suresh",
                JoiningYear = "2016",
                Designation = "Manager",
            }
       );
    }
}