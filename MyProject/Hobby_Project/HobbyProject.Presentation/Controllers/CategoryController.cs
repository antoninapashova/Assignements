
using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(result);
        }

        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();  
            return Ok(result);
        }

        [HttpGet]
        [Route("{categoryId}/subCategories/{subCategoryId}")]
        public async Task<IActionResult> GetSubCategoryFromCategory(int categoryId, int subCategoryId)
        {
            var query = new GetSubCategoryFromCategory { HobbyCategotyId = categoryId, HobbySubCategotyId = subCategoryId };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] EditCategoryCommand editCategory)
        {
             editCategory = new EditCategoryCommand { Id = id, Name = editCategory.Name };
             var result = await _mediator.Send(editCategory);

            if (result == 0) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result == 0) return NotFound();
            return NoContent();
        }

    }
}
