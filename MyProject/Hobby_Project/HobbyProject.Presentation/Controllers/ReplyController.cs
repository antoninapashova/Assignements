using Application.Categories.Commands.Delete;
using Application.Comments.Commands.Create;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.CommentReply.Commands;
using HobbyProject.Application.CommentReply.Commands.Delete;
using HobbyProject.Application.CommentReply.Queries.GetRepliesByCommentId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        public readonly IMediator _mediator;
        public ReplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReply([FromBody] CreateReplyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [Authorize]
        [HttpGet]
        [Route("{commentId}")]
        public async Task<ActionResult> GetByCommentId(int commentId)
        {
            var query = new GetRepliesByCommentIdListQuery { CommentId = commentId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteReply(int id)
        {
            var command = new DeleteReplyCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
