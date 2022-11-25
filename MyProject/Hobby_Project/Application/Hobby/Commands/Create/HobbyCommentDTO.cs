using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Create
{
    public class HobbyCommentDTO
    {
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public User User { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
