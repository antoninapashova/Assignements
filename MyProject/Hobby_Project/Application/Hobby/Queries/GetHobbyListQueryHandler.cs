using Application.Repositories;
using AutoMapper;
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
        private IMapper _mapper;

        public GetHobbyListQueryHandler(IHobbyArticleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HobbyListVm>> Handle(GetHobbyListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllEntitiesAsync();
            List<HobbyListVm> hobbyListVms = _mapper.Map<List<HobbyListVm>>(result);
            /*
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
            */

            return await Task.FromResult(hobbyListVms);
        }
     }
}
