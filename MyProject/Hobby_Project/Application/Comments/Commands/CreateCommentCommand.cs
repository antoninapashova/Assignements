using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands
{
    internal class CreateCommentCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public UserDTO User { get; set; }
     }
    
}
