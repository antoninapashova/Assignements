using Application.Hobby.Commands.Create;
using FluentValidation;

namespace HobbyProject.Application.Validators
{
    public class HobbyArticleValidator : AbstractValidator<CreateHobbyCommand>
    {
        public HobbyArticleValidator()
        {

            RuleFor(hobby => hobby.Tags).NotNull()
                .WithMessage("Tag list must contain at least one tag");

            RuleFor(hobby => hobby.Description).NotEmpty().Length(5, 10000)
                .WithMessage("Description can not be empty and must be more than 5 characters");
        }
    }
}
