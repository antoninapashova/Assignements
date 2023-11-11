using HobbyProject.Application.Categories.Dto;
using MediatR;

namespace HobbyProject.Application.Categories.Queries.GetAllNames
{
    public class GetAllNamesQuery : IRequest<IList<CategoryNameDto>> { }
}
