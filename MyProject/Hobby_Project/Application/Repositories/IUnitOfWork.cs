using HobbyProject.Application.Repositories;

namespace Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
       public IHobbyArticleRepository HobbyArticleRepository { get; }
       public ICommentRepository  CommentRepository { get; }
       public ITagRepository TagRepository { get; }
       public ISubCategoryRepository SubCategoryRepository { get; }
       public ICategoryRepository CategoryRepository { get; }
       public IPhotoRepository PhotoRepository { get; }
       public IUserRepository  UserRepository { get; }
       public IReplyRepository ReplyRepository { get; }
       
       Task Save();
    }
}
