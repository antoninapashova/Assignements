using HobbyProject.Application.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.CommentReply.Queries.GetRepliesByCommentId
{
    public class GetRepliesByCommentIdListQuery : IRequest<List<ReplyDto>>
    {
        public int CommentId { get; set; }
    }
}
