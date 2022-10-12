using System.Linq;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataSeeder
    {
        public static void SeedAuthors(CqrsDbContext context)
        {
            if (!context.Authors.Any())
            {
                LoadData(context);
                context.SaveChanges();
            }
        }

        public static void LoadData(CqrsDbContext context)
        {
            string auth1 = System.Guid.NewGuid().ToString();
            string auth2 = System.Guid.NewGuid().ToString();

            var authors = new List<Author>
                {
                new Author
                {
                    Id = auth1,
                    FirstName ="Arulprakash",
                    LastName ="S",
                    MiddleName ="Subramanian"
                },
                new Author
                {
                    Id = auth2,
                    FirstName ="Saravanan",
                    LastName ="S",
                    MiddleName ="Subramanian"
                }
                };
            context.Authors.AddRange(authors);

            var authBooks = new List<Book>()
                    {
                        new Book { Id = System.Guid.NewGuid().ToString(),AuthorId=auth1,Title = "Mastering C# 8.0"},
                        new Book { Id = System.Guid.NewGuid().ToString(),AuthorId=auth1,Title = "Entity Framework Tutorial"},
                        new Book { Id = System.Guid.NewGuid().ToString(),AuthorId=auth1,Title = "ASP.NET 4.0 Programming"},
                        new Book { Id = System.Guid.NewGuid().ToString(),AuthorId=auth2,Title = "Let us C"},
                        new Book { Id = System.Guid.NewGuid().ToString(),AuthorId=auth2,Title = "Let us C++"},
                        new Book { Id = System.Guid.NewGuid().ToString(),AuthorId=auth2,Title = "Let us C#"}
                    };
            context.Books.AddRange(authBooks);

        }
    }
}