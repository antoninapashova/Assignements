using MediatR;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryQuery : IRequest<HobbySubCategoryDto>
    {
        public int Id { get; set; }
    }
}
