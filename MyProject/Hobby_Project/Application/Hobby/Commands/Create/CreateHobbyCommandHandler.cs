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
        private readonly HobbyPublisher _publisher;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ITagRepository _tagRepository;

        public CreateHobbyCommandHandler(IHobbyRepository repository, HobbyPublisher hobbyPublisher, ISubCategoryRepository subCategoryRepository, ITagRepository tagRepository)
        {
            _repository = repository;
            _subCategoryRepository = subCategoryRepository;
            _tagRepository = tagRepository;
            _publisher = hobbyPublisher;

        }

        public Task<int> Handle(CreateHobbyCommand command, CancellationToken cancellationToken)
        {
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

            _publisher.Publish(hobby);

            return Task.FromResult(hobby.Id);
        }
    }
}
