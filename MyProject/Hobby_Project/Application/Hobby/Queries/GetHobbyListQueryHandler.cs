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
            List<HobbyListVm> hobbyListVms = _mapper.Map<List<HobbyListVm>>(result.ToList());
            return await Task.FromResult(hobbyListVms);
        }
     }
}
