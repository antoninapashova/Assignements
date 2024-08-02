using HobbyProject.Application.Constants;
using HobbyProject.Application.User.Command.Create;
using HobbyProject.Application.User.Command.ForgetPassword;
using HobbyProject.Application.User.Command.Login;
using HobbyProject.Application.User.Command.RefreshToken;
using HobbyProject.Application.User.Command.ResetPassword;
using HobbyProject.Application.User.Dto;
using HobbyProject.Application.User.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        public readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            if (id == 0) return BadRequest("Id not provided!");

            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("User")]
        public async Task<ActionResult> RegisterUser(CreateUserCommand command)
        {
            if (command == null) return BadRequest("Request body cannot be null!");

            command.Role = RoleConstants.User;
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Admin")]
        public async Task<ActionResult> RegisterAdmin(CreateUserCommand command)
        {
            if (command == null) return BadRequest("Request body cannot be null!");

            command.Role = RoleConstants.Admin;
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate(LoginUserCommand command)
        {
            if (command == null) return BadRequest("Request body cannot be null!");

            var result = await _mediator.Send(command);

            if (result == null) return NotFound("User not found");

            return Ok(new TokenApiDto
            {
                UserId = result.Id,
                AccessToken = result.Token,
                RefreshToken = result.RefreshToken
            }); 
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenCommand tokenCommand)
        {
            if (tokenCommand is null) return BadRequest("Invalid Client Request");

            var result = await _mediator.Send(tokenCommand);

            if (result == null) return NotFound("TokenApi not found");

            return Ok(new TokenApiDto()
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken,
            });
        }

        [HttpGet("Send-reset-email/{email}")]
        public async Task<IActionResult> SendEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Email not provided!");

            var command = new ForgetPasswordCommand { Email = email };
            var result = await _mediator.Send(command);
            if (result == null) return NotFound("Email not found!");

            return Ok(result);
        }

        [HttpPost("Reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
