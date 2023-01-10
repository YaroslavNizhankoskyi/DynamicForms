using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Application.Models.Dto;

namespace Application.Interfaces
{
    public interface ISignInService
    {
        Task<SignInResponse> LoginAsync(LoginCommand command);
        Task<SignInResponse> RegisterAsync(RegisterCommand command);
    }
}
