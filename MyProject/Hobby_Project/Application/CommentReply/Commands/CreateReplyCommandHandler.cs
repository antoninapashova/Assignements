using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Domain.Entity;
using MediatR;

namespace HobbyProject.Application.CommentReply.Commands
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, Reply>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateReplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<Reply> Handle(CreateReplyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var reply = _mapper.Map<Reply>(command);
                await _unitOfWork.ReplyRepository.Add(reply);
                await _unitOfWork.Save();

                return reply;
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
