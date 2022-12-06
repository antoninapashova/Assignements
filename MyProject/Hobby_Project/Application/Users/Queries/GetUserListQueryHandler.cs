using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<UserListVm>>
    {
        private readonly IUserRepository _repository;

        public GetUserListQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserListVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllEntitiesAsync();
            var users = result.Select(user => new UserListVm
            {
                Username = request.Username,
                Hobbies = user.Hobbies.Select(h => new HobbyArticleDTO
                {
                    Title = h.Title,
                    Description = h.Description,
                    HobbySubCategory = h.HobbySubCategory,
                    AddedOn = h.CreatedDate,
                   
                }).ToList()
            }).ToList();

            return await Task.FromResult(users);
        }
    }
}
