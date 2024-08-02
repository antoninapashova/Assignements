using Application.Comments.Commands.Create;
using Application.Comments.Commands.Delete;
using Application.Comments.Commands.Edit;
using HobbyProject.Application.Comments.Queries.GetCommentsByHobbyId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize]
        [HttpGet("{hobbyId}")]
        public async Task<IActionResult> GetCommentsByHobbyId(int hobbyId)
        {
            if (hobbyId == 0) return BadRequest("Id not provided!");

            var command = new GetCommentsByHobbyIdQuery { HobbyId = hobbyId };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentCommand command)
        {
            if (command == null) return BadRequest("Command can not be null!");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateComment(EditCommentCommand command)
        {
            if (command == null) return BadRequest("Command can not be null!");

            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (id == 0) return BadRequest("Id not provided!");

            var command = new DeleteCommentCommand { Id = id };
            var commentId = await _mediator.Send(command);

            return Ok(commentId);
        }
    }
}
