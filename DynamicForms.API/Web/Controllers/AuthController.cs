using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using Application.Interfaces;
using Application.Models.Dto;
using MediatR;
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
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            this._sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand model)
        {
            var result = await _sender.Send(model);

            return result.ToOk();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand model)
        {
            var result = await _sender.Send(model);

            return result.ToOk();

        }
    }
}
