
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
    }
}
