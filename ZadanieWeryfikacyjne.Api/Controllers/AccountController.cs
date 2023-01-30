using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ZadanieWeryfikacyjne.Commands;
using ZadanieWeryfikacyjne.Models;

namespace ZadanieWeryfikacyjne.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Registers a user", OperationId = nameof(Register))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The user was registered")]
        public async Task<IActionResult> Register(
            [FromBody, SwaggerRequestBody("Register user request payload", Required = true)] RegisterUserRequest model)
        {
            var command = new RegisterUser(model.Username, model.Password);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Signs a user in", OperationId = nameof(Login))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The user was signed in")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Either the user doesn't exist or the password was not correct", typeof(ProblemDetails), ContentType.JsonProblem)]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "The request did not pass validation", typeof(ProblemDetails), ContentType.JsonProblem)]
        public async Task<ActionResult> Login(
            [FromBody, SwaggerRequestBody("User login payload", Required = true)] LoginUserRequest model)
        {
            var command = new LoginUser(
                model.Username,
                model.Password);

            await _mediator.Send(command);

            return NoContent();
        }

        [Authorize]
        [HttpPost("logout")]
        [SwaggerOperation(Summary = "Signs a logged in user out", OperationId = nameof(Logout))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "The user was signed out")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Could not sign the user out because they were not signed in", typeof(ProblemDetails), ContentType.JsonProblem)]
        public async Task<ActionResult> Logout()
        {
            var command = new LogoutUser();
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
