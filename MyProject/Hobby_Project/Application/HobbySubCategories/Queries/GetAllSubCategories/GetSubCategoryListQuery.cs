using MediatR;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories
{
    public class GetSubCategoryListQuery : IRequest<IEnumerable<HobbySubCategoryDto>> { }
}
