using Application.Interfaces;
using Application.Models.Dto;
using MediatR;

namespace Application.Calls.Auth.Register
{
    public class RegisterCommand : IRequest<SignInResponse>
    {
        public string Email { get; init; }

        public string UserName { get; init; }

        public string Password { get; init; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, SignInResponse>
    {
        private readonly ISignInService _signInService;

        public RegisterCommandHandler(ISignInService signInService)
        {
            this._signInService = signInService;
        }

        public async Task<SignInResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _signInService.RegisterAsync(request);
        }
    }
}
