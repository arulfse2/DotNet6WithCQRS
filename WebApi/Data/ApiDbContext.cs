using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;
#pragma warning disable CS8618
public class ApiDbContext : DbContext
{
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    //public virtual DbSet<CompanyEmployee> CompanyEmployees { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<CompanyEmployee>().HasKey(ce => new { ce.CompanyId, ce.EmployeeId });

        // modelBuilder.Entity<CompanyEmployee>()
        //     .HasOne<Company>(ce => ce.Company)
        //     .WithMany(c => c.Employee)
        //     .HasForeignKey(ce => ce.CompanyId);

        // modelBuilder.Entity<CompanyEmployee>()
        //     .HasOne<Employee>(ce => ce.Employee)
        //     .WithMany(c => c.Company)
        //     .HasForeignKey(ce => ce.EmployeeId);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Employees)
            .WithOne(e => e.Company)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(c => c.CompanyId)
            .HasConstraintName("FK_Company_Employee");

        modelBuilder.Seed();
    }
}
#pragma warning restore CS8618