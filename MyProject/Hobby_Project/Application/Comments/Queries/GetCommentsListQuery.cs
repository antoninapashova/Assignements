using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries
{
    public class GetCommentsListQuery : IRequest<IEnumerable<CommentListVm>>
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public DateTime AddedOn { get; set; }
        public CommentUserDTO User { get; set; }
    }
}
