using BookStore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        private Func<DbContextOptions> getRequiredService;

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}
