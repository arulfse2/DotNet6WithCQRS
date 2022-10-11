using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System.Collections.Generic;

namespace WebApi.Data
{
    public class CqrsDbContext : DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseInMemoryDatabase(databaseName: "CqrsDb");
        // }
        public CqrsDbContext(DbContextOptions<CqrsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
           .HasMany<Book>(s => s.Books)
           .WithOne(g => g.Author)
           .HasForeignKey(s => s.AuthorId)
           .OnDelete(DeleteBehavior.Cascade);
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}

