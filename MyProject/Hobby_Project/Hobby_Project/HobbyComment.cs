using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbyComment
    {
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public User user { get; set; }
        public DateTime AddedOn { get; set; }

        public HobbyComment(string title, string coommentContent)
        {
            Title = title;
            CommentContent = coommentContent;
            AddedOn = DateTime.Now;
        }


    }
}
