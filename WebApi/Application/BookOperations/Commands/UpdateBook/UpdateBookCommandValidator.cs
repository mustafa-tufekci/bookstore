﻿using FluentValidation;
using WebApi.UpdateBook;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0).IsInEnum();
            RuleFor(command => command.Model.Title).MinimumLength(4); 
        }
    }
}
