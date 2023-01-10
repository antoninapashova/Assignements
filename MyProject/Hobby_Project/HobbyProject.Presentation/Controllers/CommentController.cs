
using Application.Comments.Commands.Create;
using Application.Comments.Commands.Delete;
using Application.Comments.Commands.Edit;
using HobbyProject.Application.Comments.Queries.GetAllComments;
using HobbyProject.Application.Comments.Queries.GetCommentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _mediator.Send(new GetCommentsListQuery());
            return Ok(result);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCommentByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] EditCommentCommand editComment)
        {
            editComment = new EditCommentCommand { Id = id, CommentContent = editComment.CommentContent, Title = editComment.Title };
             await _mediator.Send(editComment);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
