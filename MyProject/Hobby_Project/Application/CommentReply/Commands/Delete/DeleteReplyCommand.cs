using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.CommentReply.Commands.Delete
{
    public class DeleteReplyCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
