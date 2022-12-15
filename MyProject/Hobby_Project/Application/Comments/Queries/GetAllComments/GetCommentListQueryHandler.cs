using Application.Comments.Queries;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Comments.Queries.GetAllComments
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCommentListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CommentRepository.GetAllEntitiesAsync();
            List<CommentDto> comments = _mapper.Map<List<CommentDto>>(result);

            return await Task.FromResult(comments);
        }
    }
}
