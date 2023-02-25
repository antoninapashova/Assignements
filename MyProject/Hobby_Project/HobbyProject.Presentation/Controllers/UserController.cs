using Application.Categories.Commands.Create;
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
        /*
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateCategoryCommand command)
        {
            var validator = new CategoryValidator();

            validator.Validate(command);
            var result = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        */
    }
}
