
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int HobbyArticleId { get; set; }
    }

}
