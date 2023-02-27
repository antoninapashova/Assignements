using Application.Categories.Commands.Create;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.User.Command.Create;
using HobbyProject.Application.User.Query.GetById;
using HobbyProject.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            //var validator = new CategoryValidator();

            //validator.Validate(command);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }
        
    }
}
