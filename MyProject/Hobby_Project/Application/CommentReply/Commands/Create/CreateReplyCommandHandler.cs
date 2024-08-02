using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Domain.Entity;
using MediatR;

namespace HobbyProject.Application.CommentReply.Commands.Create
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, Reply>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public CreateReplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
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
