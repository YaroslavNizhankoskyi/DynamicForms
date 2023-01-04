using Application.Models.Dto;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Interfaces
{
    public interface IIdenityAuthService
    {
        Task<Result<Guid>> RegisterAsync(RegisterUserDto model);
        Task<SignInResult> LoginAsync(LoginUserDto model);
        Task LogoutAsync();
    }
}
