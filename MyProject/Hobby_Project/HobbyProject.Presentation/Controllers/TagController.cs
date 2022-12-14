using Application.HobbySubCategories.Commands.Create;
using Application.HobbyTags.Commands.Create;
using Application.HobbyTags.Queries;
using HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories;
using HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById;
using HobbyProject.Application.HobbyTags.Queries.GetTagById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _mediator.Send(new GetTagQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTagByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody] CreateTagCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
