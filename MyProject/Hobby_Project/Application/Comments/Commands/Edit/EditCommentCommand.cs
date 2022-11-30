using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Edit
{
    public class EditCommentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
    }
}
