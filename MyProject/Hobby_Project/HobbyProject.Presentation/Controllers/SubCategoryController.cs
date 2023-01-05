using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.HobbySubCategories.Commands.Create;
using Application.HobbySubCategories.Commands.Delete;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories;
using HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        public readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var result = await _mediator.Send(new GetSubCategoryListQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSubCategoryQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCategory([FromBody] CreateSubCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var command = new DeleteSubCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return NoContent();
        }

    }
}
