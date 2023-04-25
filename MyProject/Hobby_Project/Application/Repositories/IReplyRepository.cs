using Application.Repositories;
using Hobby_Project;
using HobbyProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Repositories
{
    public interface IReplyRepository : IRepository<Reply>
    {
        Task<IEnumerable<Reply>> GetAllRepliesByCommentId(int commentId);
    }
}
