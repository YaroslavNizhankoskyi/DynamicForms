using Application.Helpers;
using Application.Interfaces;
using Application.Models.Dto;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Calls.Auth.Register
{
    public class RegisterCommand : IRequest<Result<SignInResponse>>
    {
        public string Email{ get; init; }

        public string UserName { get; init; }

        public string Password { get; init; }
    }

    public class RegisterCommandHandler : ValidatorHandler<RegisterCommand, Result<SignInResponse>>
    {
        private readonly ISignInService _signInService;

        public RegisterCommandHandler(ICollection<IValidator<RegisterCommand>> validators,
            ISignInService signInService) : base(validators)
        {
            this._signInService = signInService;
        }
        public override Result<SignInResponse> HandleErrorRequest(string errors)
        {
            return new Result<SignInResponse>(
                new ValidationException(errors));
        }

        public override async Task<Result<SignInResponse>> HandleRequest(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _signInService.RegisterAsync(request);
        }
    }
}
