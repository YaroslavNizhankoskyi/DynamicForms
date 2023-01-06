using Application.Helpers;
using Application.Interfaces;
using Application.Models.Dto;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace Application.Calls.Auth.Login
{
    public record LoginCommand : IRequest<Result<SignInResponse>>
    {
        public string Email { get; init; }
        public string Password { get; init; }


    }

    public class LoginCommandHandler : ValidatorHandler<LoginCommand, Result<SignInResponse>>
    {
        private readonly ISignInService _signInService;

        public LoginCommandHandler(ISignInService signInService,
            IEnumerable<IValidator<LoginCommand>> validators) : base(validators)
        {
            this._signInService = signInService;
        }

        public override Result<SignInResponse> HandleErrorRequest(string errors)
        {
            return new Result<SignInResponse>(
                new ValidationException(errors));
        }

        public override async Task<Result<SignInResponse>> HandleRequest(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _signInService.LoginAsync(request);
        }
    }
}
