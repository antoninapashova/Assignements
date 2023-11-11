using Application.Categories.Commands.Create;
using FluentValidation;

namespace HobbyProject.Application.Validators
{
    public class CategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CategoryValidator()
        {   
            RuleFor(x=>x.Name).NotNull().NotEmpty().Length(3, 10)
                .WithMessage("Category name must be between 5 and 10 characters!");
        }
    }
}
