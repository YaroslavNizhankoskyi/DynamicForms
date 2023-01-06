using FluentValidation;

namespace Application.Calls.Auth.Register
{
    internal class Validator : AbstractValidator<RegisterCommand>
    {
        public Validator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .Length(2, 100);

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .Length(2, 50);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(2, 50);
        }
    }
}
