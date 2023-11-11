using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.CommentReply.Queries.GetRepliesByCommentId
{
    public class GetRepliesByCommentIdListQueryHandler : IRequestHandler<GetRepliesByCommentIdListQuery, List<ReplyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetRepliesByCommentIdListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<List<ReplyDto>> Handle(GetRepliesByCommentIdListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Reply> replies =
                     await _unitOfWork.ReplyRepository.GetAllRepliesByCommentId(request.CommentId);

                var replyListVms =
                     _mapper.Map<List<ReplyDto>>(replies);

                return await Task.FromResult(replyListVms.ToList());
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
