using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
         Task<bool> CheckSubCategoryExists(string name);
    }
}
