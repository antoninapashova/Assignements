using Application.HobbyTags.Commands.Create;
using Application.HobbyTags.Commands.Delete;
using Application.HobbyTags.Queries;
using HobbyProject.Application.HobbyTags.Queries.GetTagById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        public readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllTags()
        {
           var result = await _mediator.Send(new GetTagListQuery());
           return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0) return BadRequest("Id not provided!");

           var query = new GetTagByIdQuery { Id = id };
           var result = await _mediator.Send(query);
           return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(CreateTagCommand command)
        {
            if (command == null) return BadRequest("Request body cannot be null!");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTag(int id)
        {
            if (id == 0) return BadRequest("Id not provided!");

            var command = new DeleteTagCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
