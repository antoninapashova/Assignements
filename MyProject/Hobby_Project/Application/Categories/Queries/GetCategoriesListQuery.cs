using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<IEnumerable<CategoryListVm>>
    {
        public int ID  { get; set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        public List<HobbySubCategoryDTO> HobbySubCategories { get; set; }
    }
}
