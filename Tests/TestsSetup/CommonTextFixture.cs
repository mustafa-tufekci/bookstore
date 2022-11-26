using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace Tests.TestsSetup
{
    public class CommonTextFixture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTextFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            Context = new BookStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
    }
}
