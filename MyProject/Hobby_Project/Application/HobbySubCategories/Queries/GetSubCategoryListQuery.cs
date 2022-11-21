using Application.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Queries
{
    public class GetSubCategoryListQuery : IRequest<IEnumerable<HobbySubCategoryListVm>>
    {
        public string Name { get; set; }
    }
}
