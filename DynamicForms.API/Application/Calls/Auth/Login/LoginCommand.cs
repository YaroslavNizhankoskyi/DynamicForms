using Application.Interfaces;
using Application.Models.Dto;
using MediatR;

namespace Application.Calls.Auth.Login
{
    public record LoginCommand : IRequest<SignInResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, SignInResponse>
    {
        private readonly ISignInService _signInService;

        public LoginCommandHandler(ISignInService signInService)
        {
            this._signInService = signInService;
        }

        public async Task<SignInResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _signInService.LoginAsync(request);
        }
    }
}
