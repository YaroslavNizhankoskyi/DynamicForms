﻿using FluentValidation;

namespace Application.Calls.Auth.Login
{
    public class Validator : AbstractValidator<LoginCommand>
    {
        public Validator()
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .Length(2, 50)
                .NotEmpty();

            RuleFor(c => c.Password)
                .NotEmpty()
                .Length(2, 50);
        }
    }
}
