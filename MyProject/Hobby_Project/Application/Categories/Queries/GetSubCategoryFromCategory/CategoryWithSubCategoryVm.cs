using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory
{
    public  class CategoryWithSubCategoryVm
    {
        public string Name { get; set; }
        public HobbySubCategoryDto HobbySubCategoryDTO { get; set; }
    }
}
