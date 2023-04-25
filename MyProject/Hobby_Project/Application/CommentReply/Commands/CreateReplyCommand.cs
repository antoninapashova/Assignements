using Hobby_Project;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.CommentReply.Commands
{
    public class CreateReplyCommand : IRequest<Reply>
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
       
    }
}
