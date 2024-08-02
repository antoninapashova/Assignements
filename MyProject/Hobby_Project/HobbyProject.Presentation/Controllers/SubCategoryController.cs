using Application.HobbySubCategories.Commands.Create;
using Application.HobbySubCategories.Commands.Delete;
using HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories;
using HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        public readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var result = await _mediator.Send(new GetSubCategoryListQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0) return BadRequest("Id not provided!");

            var query = new GetSubCategoryQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddSubCategory(CreateSubCategoryCommand command)
        {
            if (command == null) return BadRequest("Request body cannot be null!");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            if (id == 0) return BadRequest("Id not provided!");

            var command = new DeleteSubCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
