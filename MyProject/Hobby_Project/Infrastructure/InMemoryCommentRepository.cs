using Application;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class InMemoryCommentRepository : ICommentRepository
    {
        List<HobbyComment> _comments = new();
        public void CreateComment(HobbyComment comment)
        {
            _comments.Add(comment);
            comment.ID = _comments.Count;
        }

        public void DeleteComment(HobbyComment hobbyComment)
        {
            var comment = _comments.FirstOrDefault(c => c.ID == hobbyComment.ID);
            if (comment== null) throw new InvalidOperationException("Comment with that ID does not exist!");
            this._comments.Remove(comment);
        }

        public IEnumerable<HobbyComment> GetAllComments()
        {
            return this._comments;
        }

        public HobbyComment getHobbyComment(int commentId)
        {
            var comment = _comments.FirstOrDefault(c => c.ID == commentId);
            if (comment == null) throw new InvalidOperationException("Comment with that ID does not exist!");
            return comment;
        }

        public void UpdateComment(int commentId, HobbyComment newHobbyComment)
        {
            var comment = _comments.FirstOrDefault(c => c.ID == commentId);
            if (comment == null) throw new InvalidOperationException("Comment with that ID does not exist!");
            comment.Title = newHobbyComment.Title;
            comment.CommentContent = newHobbyComment.CommentContent;
            comment.AddedOn = DateTime.Now;
            comment.user = newHobbyComment.user;

        }
    }
}
