using Hobby_Project;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IQueryable<Category>> GetAllNamesAsync();
        Task<bool> CheckCategoryExists(string name);
    }
}
