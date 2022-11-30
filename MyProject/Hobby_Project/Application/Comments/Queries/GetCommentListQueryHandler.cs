using Application.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<CommentListVm>>
    {
        private readonly ICommentRepository _commentRepository;
        

        public GetCommentListQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            
        }

        public Task<IEnumerable<CommentListVm>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var result = _commentRepository.GetAllComments().Select(comment => new CommentListVm
            {
                CommentId = comment.Id,
                Title = comment.Title,
                AddedOn = comment.AddedOn,
                CommentContent = comment.CommentContent,
                Username = comment.User.Username
            });
            return Task.FromResult(result);
        }
    }
}
