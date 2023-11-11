using MediatR;

namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class GetCategoriesListQuery : IRequest<List<CategoryDto>>
    {
    }
}
