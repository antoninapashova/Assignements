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
            var comments = new List<HobbyComment>
            {
                new HobbyComment{Id=1, CommentContent=".......", Title="-------", HobbyArticleId=1, UserId=1},
                new HobbyComment{Id=2, CommentContent=".......", Title="-------", HobbyArticleId=1, UserId=1},
                new HobbyComment{Id=3, CommentContent=".......", Title="-------", HobbyArticleId=1, UserId=1},
            };
            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(comments);

            mockRepo.Setup(x => x.Add(It.IsAny<HobbyComment>())).ReturnsAsync((HobbyComment comment) =>
            {
                comments.Add(comment);
                return comment;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<HobbyComment>())).ReturnsAsync((HobbyComment comment) =>
            {
                HobbyComment? hobbyComment1 = comments.FirstOrDefault(x => x.Id == comment.Id);
                hobbyComment1.Title = comment.Title;
                hobbyComment1.CommentContent = comment.CommentContent;
                hobbyComment1.CreatedDate = DateTime.Now;
                return hobbyComment1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int commentId) =>
            {
                HobbyComment? hobbyComment1 = comments.FirstOrDefault(x => x.Id == commentId);
                comments.Remove(hobbyComment1);

                return Task.FromResult(hobbyComment1.Id);
            });
            return mockRepo;
        }
    }
}
