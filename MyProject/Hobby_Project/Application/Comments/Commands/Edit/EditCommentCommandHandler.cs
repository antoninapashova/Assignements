using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Edit
{
    internal class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private ILog _log;
        private IMapper _mapper;

        public EditCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(EditCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Edit comment command is null");                
                await _commentRepository.UpdateAsync(command.Id, _mapper.Map<HobbyComment>(command));
                return await Task.FromResult(command.Id);

            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
