using Application.Calls.Forms.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class FormsController
    {
        private readonly ISender _sender;

        public FormsController(ISender sender)
        {
            this._sender = sender;
        }

        public async Task<IActionResult> Create(CreateFormCommand command)
        {
            return new OkObjectResult(await _sender.Send(command));
        }


        public async Task<IActionResult> GetUserCreated()
        {
            throw new NotImplementedException();
        }
    }
}
