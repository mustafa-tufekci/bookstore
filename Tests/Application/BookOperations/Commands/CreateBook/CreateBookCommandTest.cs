using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestsSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOperations.Commands.CreateCommand
{
	public class CreateBookCommandTest : IClassFixture<CommonTextFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public CreateBookCommandTest(CommonTextFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn()
		{
			//arrange (Hazırlık)
			var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1990, 01, 10), GenreId = 1 };
			_context.Books.Add(book);
			_context.SaveChanges();

			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			command.Model = new CreateBookModel() { Title = book.Title };

			//act & assert (Çalıştırma)
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut.");
		}
	}

}
