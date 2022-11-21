using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands
{
    internal class CreateHobbyCommandHandler : IRequestHandler<CreateHobbyCommand, int>
    {
        private readonly IHobbyRepository _repository;

        public CreateHobbyCommandHandler(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(CreateHobbyCommand command, CancellationToken cancellationToken)
        {
            var hobbySubCategory = new HobbySubCategory(command.HobbySubCategory.Name);

            var hobbyComments = command.Comments.Select(hobbyCommentDTO =>
                  new HobbyComment(hobbyCommentDTO.Title, hobbyCommentDTO.CommentContent, hobbyCommentDTO.User)).ToList();

            var hobbyTags = command.Tags.Select(tagDTO =>
                 new Tag(tagDTO.Name)).ToList();

            var hobby = new HobbyArticle(command.Title, command.Description, hobbySubCategory, hobbyComments, hobbyTags);
            _repository.CreateHobby(hobby);
            return Task.FromResult(hobby.ID);
        }
    }
}
