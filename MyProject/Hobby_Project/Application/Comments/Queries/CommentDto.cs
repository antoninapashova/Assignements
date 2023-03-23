using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentContent { get; set; } 
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
