using HobbyProject.Application.Categories.Dto;
using MediatR;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoriesListQuery : IRequest<IList<CategoryDto>>
    {
    }
}
