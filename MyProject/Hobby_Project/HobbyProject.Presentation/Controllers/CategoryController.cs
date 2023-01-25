
using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory;
using HobbyProject.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.ComponentModel.DataAnnotations;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]

    public class CategoryController : ControllerBase
    {
        public readonly IMediator _mediator;
        
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
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
            var query = new GetCategoryByIdQuery { Id = id };
            var result = await _mediator.Send(query); 
            return Ok(result);
        }

        [HttpGet]
        [Route("{categoryId}/subCategories/{subCategoryId}")]
        public async Task<ActionResult> GetSubCategoryFromCategory(int categoryId, int subCategoryId)
        {
            var query = new GetSubCategoryFromCategory { HobbyCategotyId = categoryId, HobbySubCategotyId = subCategoryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CreateCategoryCommand command)
        {
            var validator = new CategoryValidator(); 
            
            validator.Validate(command);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] EditCategoryCommand editCategory)
        {
             editCategory = new EditCategoryCommand { Id = id, Name = editCategory.Name };
             var result = await _mediator.Send(editCategory);
             return Ok(result);
        }

        [Authorize(Roles = "Admin")]
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
