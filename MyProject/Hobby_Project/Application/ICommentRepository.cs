using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICommentRepository
    {
        void CreateComment(HobbyComment comment);
        void DeleteComment(HobbyComment hobbyComment);

        void UpdateComment(int commentId, HobbyComment comment);
        HobbyComment getHobbyComment(int commentId);
        IEnumerable<HobbyComment> GetAllComments();
    }
}
