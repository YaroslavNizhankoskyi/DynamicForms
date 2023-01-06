using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Infrastructure.Data.Identity.Models;
using Infrastructure.Services.Interfaces;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    internal class IdentityAuthService : IIdenityAuthService
    {
        private const string UserNotFound = "User not found";
        private const string UserExists = "User already exists";
        private const string CouldNotSignIn = "Could not sign in";
        private const string AfterRegisterSignInFailed = "User registered but failed to sign in";

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public IdentityAuthService(UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(LoginCommand dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            return await _signInManager
                .PasswordSignInAsync(user, dto.Password, true, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Result<Guid>> RegisterAsync(RegisterCommand dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return new Result<Guid>(
                    new NullReferenceException(UserExists));
            }

            var user = new User()
            {
                Email = dto.Email,
                UserName = dto.UserName
            };

            var createUserResult = await _userManager.CreateAsync(user, dto.Password);

            if (!createUserResult.Succeeded)
            {
                var errors = createUserResult.Errors
                    .Select(x => x.Description);

                var errorsCombined = String.Join(", ", errors);

                return new Result<Guid>(
                    new Exception(errorsCombined));
            }

            var signInRes = await _signInManager
                .PasswordSignInAsync(user, dto.Password, true, false);

            if (!signInRes.Succeeded)
            {
                return new Result<Guid>(
                    new NullReferenceException(AfterRegisterSignInFailed));
            }

            return new Result<Guid>(user.Id);
        }
    }
}
