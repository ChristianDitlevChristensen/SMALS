using Microsoft.EntityFrameworkCore;
using SMALS.Models;

namespace SMALS.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Harry Potter",
                            Author = "JK Rowling",
                            ISBN = "111",
                            Status = true
                         },
                        new Book()
                        {
                            Title = "Harry Potter",
                            Author = "JK Rowling",
                            ISBN = "112",
                            Status = true
                         },
                        new Book()
                        {
                            Title = "Hunger Games",
                            Author = "Suzanne Collins",
                            ISBN = "221",
                            Status = true
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            Name = "Christian Ditlev Christensen"
                         }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
