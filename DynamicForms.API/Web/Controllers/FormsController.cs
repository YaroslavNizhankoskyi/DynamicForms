using Application.Calls.Forms.Create;
using Application.Calls.Forms.Get;
using Application.Calls.Forms.GetPublic;
using Application.Calls.Forms.GetUserCreated;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/forms")]
    [ApiController]
    public class FormsController
    {
        private readonly ISender _sender;

        public FormsController(ISender sender)
        {
            this._sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFormCommand command)
        {
            return new OkObjectResult(await _sender.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            var command = new GetAllFormsQuery();

            return new OkObjectResult(await _sender.Send(command));
        }

        [HttpGet("created")]
        public async Task<IActionResult> GetUserCreatedForms()
        {
            var command = new GetUserCreatedForms();

            return new OkObjectResult(await _sender.Send(command));
        }

        [HttpGet("public")]
        public async Task<IActionResult> GetPublicForms()
        {
            var command = new GetPublicForms();

            return new OkObjectResult(await _sender.Send(command));
        }
    }
}
