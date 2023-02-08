using Application.Repositories;
using Hobby_Project;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Mocks
{
    public static class MockCommentRepository
    {
        public static Mock<ICommentRepository> GetAllComments()
        {
            var comments = new List<Comment>
            {
                new Comment{Id=1, CommentContent=".......",  HobbyArticleId=1},
                new Comment{Id=2, CommentContent=".......",  HobbyArticleId=1},
                new Comment{Id=3, CommentContent=".......",  HobbyArticleId=1},
            };
            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(comments);

            mockRepo.Setup(x => x.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
            {
                comments.Add(comment);
                return comment;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
            {
                Comment? hobbyComment1 = comments.FirstOrDefault(x => x.Id == comment.Id);
                hobbyComment1.CommentContent = comment.CommentContent;
                hobbyComment1.CreatedDate = DateTime.Now;
                return hobbyComment1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int commentId) =>
            {
                Comment? hobbyComment1 = comments.FirstOrDefault(x => x.Id == commentId);
                comments.Remove(hobbyComment1);
                return Task.FromResult(hobbyComment1.Id);
            });
            return mockRepo;
        }
    }
}
