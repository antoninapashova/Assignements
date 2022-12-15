using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoriesListQuery : IRequest<List<CategoryDto>>
    {

    }
}
