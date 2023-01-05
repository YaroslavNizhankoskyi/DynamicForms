using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Application.Models.Dto;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Interfaces
{
    public interface IIdenityAuthService
    {
        Task<Result<Guid>> RegisterAsync(RegisterCommand model);
        Task<SignInResult> LoginAsync(LoginCommand model);
        Task LogoutAsync();
    }
}
