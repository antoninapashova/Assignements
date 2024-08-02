using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetAllNames;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public readonly IMediator _mediator;
        
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("All")]
        public async Task<ActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("AllNames")]
        public async Task<ActionResult> GetAllNames()
        {
            var result = await _mediator.Send(new GetAllNamesQuery());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var result = await _mediator.Send(query); 
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CreateCategoryCommand command)
        {
            if (command == null) return BadRequest("Category command is null!");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (id == 0) return BadRequest("Id not found!");

            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
