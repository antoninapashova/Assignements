using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Queries
{
    public class GetHobbyListQueryHandler : IRequestHandler<GetHobbyListQuery, IEnumerable<HobbyListVm>>
     {
       private readonly IHobbyArticleRepository _repository;

        public GetHobbyListQueryHandler(IHobbyArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HobbyListVm>> Handle(GetHobbyListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllEntitiesAsync();
            var hobbies = result.Select(hobby => new HobbyListVm
            {
                Title = hobby.Title,
                Description = hobby.Description,
                hobbySubCategory = hobby.HobbySubCategory,
                Comments = hobby.HobbyComments.Select(com => new HobbyCommentDTO
                {
                    CommentContent = com.CommentContent,
                    Title = com.Title,
                    Username = com.User.Username,
                }).ToList(),
                Tags = hobby.HobbyTags.Select(tag => new TagDTO
                {
                    Name = tag.Tag.Name
                }).ToList()
            }); 

            return await Task.FromResult(hobbies.ToList());
        }
     }
}
