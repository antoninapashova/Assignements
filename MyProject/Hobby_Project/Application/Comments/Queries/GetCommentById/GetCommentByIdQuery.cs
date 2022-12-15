using Application.Comments.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
