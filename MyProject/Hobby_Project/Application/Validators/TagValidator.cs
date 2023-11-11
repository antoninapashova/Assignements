using Application.HobbyTags.Commands.Create;
using FluentValidation;

namespace HobbyProject.Application.Validators
{
    public class TagValidator : AbstractValidator<CreateTagCommand>
    {
        public TagValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().Length(3, 20)
                .WithMessage("Tag name must be between 3 and 20 characters!");
        }
    }
}
