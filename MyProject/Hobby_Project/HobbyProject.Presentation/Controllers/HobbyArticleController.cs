using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Hobby.Commands.Create;
using Application.Hobby.Commands.Delete;
using Application.Hobby.Queries;
using Application.Users.Commands.Create;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Hobby.Queries.GetAllUsers;
using HobbyProject.Application.Hobby.Queries.GetHobbyById;
using HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories;
using HobbyProject.Application.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyArticleController : ControllerBase
    {

        public readonly IMediator _mediator;

        public HobbyArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHobbyArticles()
        {
            var result = await _mediator.Send(new GetHobbyListQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetHobbyByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddHobbyArticle([FromBody] CreateHobbyCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var command = new DeleteHobbyCommand { Id = id };
            var result = await _mediator.Send(command);
            return NoContent();
        }
    }
}
