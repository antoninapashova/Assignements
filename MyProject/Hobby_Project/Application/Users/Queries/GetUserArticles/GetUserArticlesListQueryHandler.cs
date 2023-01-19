using Application.Hobby.Queries;
using Application.Logger;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Users.Queries.GetUserArticles
{
    public class GetUserArticlesListQueryHandler : IRequestHandler<GetUserArticlesListQuery, IEnumerable<HobbyArticleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _logger;

        public GetUserArticlesListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            _logger = SingletonLogger.Instance;
        }

        public async Task<IEnumerable<HobbyArticleDTO>> Handle(GetUserArticlesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
               if (request == null) throw new NullReferenceException("Hobby by userId query is null");

               var result = await _unitOfWork.HobbyArticleRepository.GetHobbyArticlesByUserId(request.Id);
               IEnumerable<HobbyArticleDTO> hobbyVm = _mapper.Map<IEnumerable<HobbyArticleDTO>>(result.ToList());
               return await Task.FromResult(hobbyVm);

            }catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
