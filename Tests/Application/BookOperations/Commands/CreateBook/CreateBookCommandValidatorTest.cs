using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using Tests.TestsSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.Application.BookOperations.Commands.CreateBook
{
	public class CreateBookCommandValidatorTest : IClassFixture<CommonTextFixture>
	{
		[Theory]
		[InlineData("Lord Of The Rings", 0, 0)]
		[InlineData("Lord Of The Rings", 0, 1)]
		[InlineData("Lord Of The Rings", 100, 0)]
		[InlineData("", 0, 0)]
		[InlineData("", 100, 1)]
		[InlineData("", 0, 1)]
		[InlineData("Lord", 100, 0)]
		[InlineData("Lord", 0, 1)]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
		{
			//arrange
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel()
			{
				Title = title,
				PageCount = pageCount,
				PublishDate = DateTime.Now.Date.AddYears(-1),
				GenreId = genreId
			};

			//act
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);

			//assert
			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
