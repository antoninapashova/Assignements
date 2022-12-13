using HobbyProject.Application.Categories.Queries.GetAllCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory
{
     public  class GetSubCategoryFromCategory : IRequest<CategoryWithSubCategoryVm>
    {
        public int HobbyCategotyId { get; set; }
        public int HobbySubCategotyId { get; set; }
    }
}
