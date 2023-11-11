using HobbyProject.Application.User;
using HobbyProject.Application.User.Command.Create;
using HobbyProject.Application.User.Command.ForgetPassword;
using HobbyProject.Application.User.Command.Login;
using HobbyProject.Application.User.Command.RefreshToken;
using HobbyProject.Application.User.Command.ResetPassword;
using HobbyProject.Application.User.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] LoginUserCommand obj)
        {
            if (obj == null) return BadRequest();
            var result = await _mediator.Send(obj);

            if (result == null) return NotFound(new { Message = "User not found" });

            return Ok(new TokenApiDto
            {
                UserId = result.Id,
                AccessToken = result.Token,
                RefreshToken = result.RefreshToken
            }); 
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenCommand tokenCommand)
        {
            if (tokenCommand is null) return BadRequest("Invalid Client Request");

            var result = await _mediator.Send(tokenCommand);

            return Ok(new TokenApiDto()
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken,
            });
        }


        [HttpGet("send-reset-email/{email}")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var command = new ForgetPasswordCommand
            {
                Email = email
             };
             await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
