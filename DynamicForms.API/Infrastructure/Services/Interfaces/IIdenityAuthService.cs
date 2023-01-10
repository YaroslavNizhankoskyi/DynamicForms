using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Interfaces
{
    public interface IIdenityAuthService
    {
        Task<Guid> RegisterAsync(RegisterCommand model);
        Task<SignInResult> LoginAsync(LoginCommand model);
        Task LogoutAsync();
    }
}
