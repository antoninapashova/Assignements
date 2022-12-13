using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public ICollection<HobbySubCategoryDTO> HobbySubCategories { get; set; }

    }
}
