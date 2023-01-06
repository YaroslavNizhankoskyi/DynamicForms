using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Application.Helpers.Exceptions;
using Application.Interfaces;
using Application.Models.Dto;
using Domain;
using Infrastructure.Services.Interfaces;
using LanguageExt.Common;

namespace Infrastructure.Services
{
    internal class SignInService : ISignInService
    {
        private const string FailedToSignIn = "Failed to sign in";
        private const string FailedToCreateUser = "Failed to register";

        private readonly IIdenityAuthService _idenityAuthService;
        private readonly IDomainDbContext _domainDb;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public SignInService(IIdenityAuthService idenityAuthService, IDomainDbContext domainDb,
            ITokenService tokenService, IUserService userService)
        {
            this._idenityAuthService = idenityAuthService;
            this._domainDb = domainDb;
            this._tokenService = tokenService;
            this._userService = userService;
        }

        public async Task<Result<SignInResponse>> LoginAsync(LoginCommand dto)
        {
            var idAuthResult = await _idenityAuthService.LoginAsync(dto);

            if (!idAuthResult.Succeeded)
            {
                return new Result<SignInResponse>(
                    new SignInFailureException(FailedToSignIn));
            }

            return new Result<SignInResponse>(
                await GetSignInResponse(dto.Email));
        }

        public async Task<Result<SignInResponse>> RegisterAsync(RegisterCommand dto)
        {
            var registerSignInResult = await _idenityAuthService.RegisterAsync(dto);

            if (registerSignInResult.IsFaulted)
            {
                return registerSignInResult.Match<Result<SignInResponse>>
                    (res => default(Result<SignInResponse>),
                    exc => new Result<SignInResponse>(exc));
            }

            var id = registerSignInResult.Match<Guid>(x => x, exc => default(Guid));

            var domainUser = new DomainUser
            {
                UserAuthId = id,
                UserName = dto.UserName,
                Email = dto.Email
            };

            _domainDb.DomainUsers.Add(domainUser);

            if (_domainDb.SaveChanges() <= 0)
            {
                return new Result<SignInResponse>(
                    new SignInFailureException(FailedToCreateUser));
            }

            return new Result<SignInResponse>(
                await GetSignInResponse(dto.Email));
        }

        private async Task<SignInResponse> GetSignInResponse(string userEmail)
        {
            var user = await _userService.GetUserDetailsByEmail(userEmail);

            var token = await _tokenService.CreateToken(user.Email);

            return new SignInResponse(
                    user.Email,
                    user.Id,
                    user.Name,
                    user.Role,
                    token);
        }
    }
}
