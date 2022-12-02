using Application.Logger;
using Application.Notifications;
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
        private readonly IHobbyRepository _repository;
      
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ITagRepository _tagRepository;
        private ILog _log;

        public CreateHobbyCommandHandler(IHobbyRepository repository, ISubCategoryRepository subCategoryRepository, ITagRepository tagRepository)
        {
            _repository = repository;
            _subCategoryRepository = subCategoryRepository;
            _tagRepository = tagRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(CreateHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create hobby command is null!");
                var hobbySubCategory = _subCategoryRepository.GetSubCategory(command.HobbySubCategory.SubCategoryID);

                var hobbyComments = new List<HobbyComment>();
                var hobbyTags = new List<Tag>();

                foreach (var tag in command.Tags)
                {
                    Tag tag1 = _tagRepository.GetTag(tag.TagId);
                    hobbyTags.Add(tag1);
                }
                 var hobby = new HobbyArticle(command.Title, command.Description, hobbySubCategory, hobbyComments, hobbyTags);
                _repository.CreateHobby(hobby);
                return Task.FromResult(hobby.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
            
        }
    }
}
