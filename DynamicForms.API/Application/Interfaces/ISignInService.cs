using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Application.Models.Dto;
using LanguageExt.Common;

namespace Application.Interfaces
{
    public interface ISignInService
    {
        Task<Result<SignInResponse>> LoginAsync(LoginCommand command);
        Task<Result<SignInResponse>> RegisterAsync(RegisterCommand command);
    }
}
