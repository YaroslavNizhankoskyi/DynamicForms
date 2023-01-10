using Application.Calls.Auth.Login;
using Application.Calls.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return new OkObjectResult(await _sender.Send(model));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand model)
        {
            return new OkObjectResult(await _sender.Send(model));
        }
    }
}
