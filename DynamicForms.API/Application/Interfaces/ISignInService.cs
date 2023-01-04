using Application.Models.Dto;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISignInService
    {
        Task<Result<SignInResponseDto>> LoginAsync(LoginUserDto dto);
        Task<Result<SignInResponseDto>> RegisterAsync(RegisterUserDto dto);
    }
}
