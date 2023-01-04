using Application.Interfaces;
using Application.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthController
    {
        private readonly ISignInService _signInService;

        public AuthController(ISignInService signInService)
        {
            this._signInService = signInService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            var result = await _signInService.LoginAsync(model);

            return result.ToOk();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto model)
        {
            var result = await _signInService.RegisterAsync(model);

            return result.ToOk();
        }
    }
}
