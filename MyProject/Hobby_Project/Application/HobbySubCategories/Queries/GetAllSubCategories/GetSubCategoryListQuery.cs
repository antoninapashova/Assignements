using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories
{
    public class GetSubCategoryListQuery : IRequest<IEnumerable<HobbySubCategoryVm>>
    {
        public string Name { get; set; }
    }
}
