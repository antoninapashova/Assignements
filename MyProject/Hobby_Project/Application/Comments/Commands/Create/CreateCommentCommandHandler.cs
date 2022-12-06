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

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _repository;
        private readonly IUserRepository _userRepository;
        private ILog _log;
        private IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository repository, 
            IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create comment command is null");
                HobbyComment hobbyComment = _mapper.Map<HobbyComment>(command);
                await _repository.Add(hobbyComment);
                return await Task.FromResult(hobbyComment.Id);
            } catch(Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
