using Application.Models.Dto;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IIdenityAuthService
    {
        Task<Result<Guid>> RegisterAsync(RegisterUserDto model);
        Task<SignInResult> LoginAsync(LoginUserDto model);
        Task LogoutAsync();
    }
}
