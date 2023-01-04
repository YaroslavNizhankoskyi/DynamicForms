using Application.Models.Dto;
using LanguageExt.Common;

namespace Application.Interfaces
{
    public interface ISignInService
    {
        Task<Result<SignInResponseDto>> LoginAsync(LoginUserDto dto);
        Task<Result<SignInResponseDto>> RegisterAsync(RegisterUserDto dto);
    }
}
