using Application.Categories.Commands.Create;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.User.Command.Create;
using HobbyProject.Application.User.Command.Login;
using HobbyProject.Application.User.Query.GetById;
using HobbyProject.Application.Validators;
using HobbyProject.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            
            return Ok(new
            {
                Token = result.Token,
                Message = "Login success"
            });
        }
    }
}
