using MediatR;

namespace HobbyProject.Application.Categories.Queries.GetAllNames
{
    public class GetAllNamesQuery : IRequest<List<CategoryNameDto>>
    {
    }
}
