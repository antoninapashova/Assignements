using HobbyProject.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       
       Task Save();

    }
}
