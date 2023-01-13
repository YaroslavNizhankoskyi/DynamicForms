using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Application.Helpers.Exceptions;
using Application.Interfaces;
using Application.Models.Dto;
using Domain;
using Infrastructure.Services.Interfaces;

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

        public async Task<SignInResponse> LoginAsync(LoginCommand dto)
        {
            var idAuthResult = await _idenityAuthService.LoginAsync(dto);

            if (!idAuthResult.Succeeded)
            {
                throw new SignInFailureException(FailedToSignIn);
            }

            return await GetSignInResponse(dto.Email);
        }

        public async Task<SignInResponse> RegisterAsync(RegisterCommand dto)
        {
            var userGuid = await _idenityAuthService.RegisterAsync(dto); ;

            var domainUser = new DomainUser
            {
                UserAuthId = userGuid,
                UserName = dto.UserName,
                Email = dto.Email
            };

            _domainDb.DomainUsers.Add(domainUser);

            if (_domainDb.SaveChanges() <= 0)
            {
                throw new SignInFailureException(FailedToCreateUser);
            }

            return await GetSignInResponse(dto.Email);
        }

        private async Task<SignInResponse> GetSignInResponse(string userEmail)
        {
            var user = await _userService.GetUserDetailsByEmail(userEmail);

            var token = await _tokenService.CreateToken(user.Email);

            return new SignInResponse(
                    user.Email,
                    user.AuthId,
                    user.Name,
                    user.Role,
                    token);
        }
    }
}
