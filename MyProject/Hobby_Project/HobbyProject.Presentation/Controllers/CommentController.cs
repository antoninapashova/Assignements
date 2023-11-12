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
            var command = new GetCommentsByHobbyIdQuery
            {
                HobbyId = hobbyId
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] EditCommentCommand editComment)
        {
            var command = new EditCommentCommand
            {
                Id = id,
                CommentContent = editComment.CommentContent,
            };
           
            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand { Id = id };
            var commentId = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
