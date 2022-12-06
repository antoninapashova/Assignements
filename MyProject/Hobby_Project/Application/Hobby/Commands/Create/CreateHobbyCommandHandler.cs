using Application.Logger;
using Application.Notifications;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Create
{
    public class CreateHobbyCommandHandler : IRequestHandler<CreateHobbyCommand, int>
    {
        private readonly IHobbyArticleRepository _repository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ITagRepository _tagRepository;
        private ILog _log;
        private IMapper _mapper;

        public CreateHobbyCommandHandler(IHobbyArticleRepository repository, ISubCategoryRepository subCategoryRepository, ITagRepository tagRepository, IMapper mapper)
        {
            _repository = repository;
            _subCategoryRepository = subCategoryRepository;
            _tagRepository = tagRepository;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create hobby command is null!");
                var hobby = _mapper.Map<HobbyArticle>(command);
                await _repository.Add(hobby);
                return await Task.FromResult(hobby.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
