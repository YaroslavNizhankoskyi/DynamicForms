using Application.Helpers.Exceptions;
using Application.Interfaces;
using Application.Models.Dto;
using Domain;
using Infrastructure.Data.Domain;
using Infrastructure.Services.Interfaces;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class SignInService : ISignInService
    {
        private const string FailedToSignIn = "Failed to sign in";
        private const string FailedToCreateUser = "Failed to register";  

        private readonly IIdenityAuthService _idenityAuthService;
        private readonly DomainDbContext _domainDb;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public SignInService(IIdenityAuthService idenityAuthService, DomainDbContext domainDb,
            ITokenService tokenService, IUserService userService)
        {
            this._idenityAuthService = idenityAuthService;
            this._domainDb = domainDb;
            this._tokenService = tokenService;
            this._userService = userService;
        }

        public async Task<Result<SignInResponseDto>> LoginAsync(LoginUserDto dto)
        {
            var idAuthResult = await _idenityAuthService.LoginAsync(dto);

            if (!idAuthResult.Succeeded)
            {
                return new Result<SignInResponseDto>(
                    new SignInFailureException(FailedToSignIn));
            }

            return new Result<SignInResponseDto>(
                await GetSignInResponse(dto.Email));
        } 

        public async Task<Result<SignInResponseDto>> RegisterAsync(RegisterUserDto dto)
        {
            var registerSignInResult = await _idenityAuthService.RegisterAsync(dto);

            if (registerSignInResult.IsFaulted)
            {
                return registerSignInResult.Match<Result<SignInResponseDto>>
                    (res => default(Result<SignInResponseDto>),
                    exc => new Result<SignInResponseDto>(exc));
            }

            var id = registerSignInResult.Match<Guid>(x => x, exc => default(Guid));

            var domainUser = new DomainUser
            {
                UserAuthId = id,
                UserName = dto.UserName,
                Email = dto.Email
            };

            _domainDb.DomainUsers.Add(domainUser);

            if(_domainDb.SaveChanges() <= 0)
            {
                return new Result<SignInResponseDto>(
                    new SignInFailureException(FailedToCreateUser));
            }

            return new Result<SignInResponseDto>(
                await GetSignInResponse(dto.Email));
        }

        private async Task<SignInResponseDto> GetSignInResponse(string userEmail)
        {
            var user = await _userService.GetUserDetailsByEmail(userEmail);

            var token = await _tokenService.CreateToken(user.Email);

            return new SignInResponseDto(
                    user.Email, 
                    user.Id, 
                    user.Name, 
                    user.Role, 
                    token);
        }
    }
}
