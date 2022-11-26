using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
            new Book { Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 14) },
            new Book { Title = "Herland", GenreId = 2, PageCount = 200, PublishDate = new DateTime(2010, 05, 13) },
            new Book { Title = "Dune", GenreId = 1, PageCount = 150, PublishDate = new DateTime(2001, 12, 15) });
        }
    }
}
