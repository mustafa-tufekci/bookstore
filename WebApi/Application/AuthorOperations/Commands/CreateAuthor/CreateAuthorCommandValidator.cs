﻿using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty();
            RuleFor(command => command.Model.LastName).NotEmpty();
            RuleFor(command => command.Model.DateOfBirth).NotEmpty();
        }
    }
}
