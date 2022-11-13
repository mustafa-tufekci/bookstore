using BookStore;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Orhan",
                        LastName = "Pamuk",
                        DateOfBirth = new DateTime(1952, 06,15)
                    },
                    new Author
                    {
                        FirstName = "Sabahattin",
                        LastName = "Ali",
                        DateOfBirth = new DateTime(1907, 02, 25)
                    },
                    new Author
                    {
                        FirstName = "Yaşar",
                        LastName = "Kemal",
                        DateOfBirth = new DateTime(1923, 09, 06)
                    }
                );
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Noval"
                    }
                );

                context.Books.AddRange(
                new Book
                {
                    //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1, 
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 14)
                },
                new Book
                {
                    //Id = 2,
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 200,
                    PublishDate = new DateTime(2010, 05, 13)
                },
                new Book
                {
                    //Id = 3,
                    Title = "Dune",
                    GenreId = 1, 
                    PageCount = 150,
                    PublishDate = new DateTime(2001, 12, 15)
                });

                context.SaveChanges();
            }
        }
    }
}
