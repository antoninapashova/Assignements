using Hobby_Project;
using HobbyProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<bool> CheckTagExists(string name);
    }
}
