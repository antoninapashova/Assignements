
using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory;
using HobbyProject.Presentation.Middleware;
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
        public async Task<ActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(result);
        }

        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
               var query = new GetCategoryByIdQuery { Id = id };
               var result = await _mediator.Send(query); 
               return Ok(result);
            }catch(Exception e)
            {
                return NotFound();  
            }
        }

        [HttpGet]
        [Route("{categoryId}/subCategories/{subCategoryId}")]
        public async Task<ActionResult> GetSubCategoryFromCategory(int categoryId, int subCategoryId)
        {
            var query = new GetSubCategoryFromCategory { HobbyCategotyId = categoryId, HobbySubCategotyId = subCategoryId };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] EditCategoryCommand editCategory)
        {
             editCategory = new EditCategoryCommand { Id = id, Name = editCategory.Name };
             var result = await _mediator.Send(editCategory);
             
             return Ok(result);
        }
        

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
