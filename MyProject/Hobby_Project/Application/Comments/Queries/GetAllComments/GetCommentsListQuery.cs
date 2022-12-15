using Application.Comments.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Comments.Queries.GetAllComments
{
    public class GetCommentsListQuery : IRequest<IEnumerable<CommentDto>>
    {
       
    }
}
