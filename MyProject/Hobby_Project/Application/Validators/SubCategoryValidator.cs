using Application.HobbySubCategories.Commands.Create;
using FluentValidation;

namespace HobbyProject.Application.Validators
{
    public class SubCategoryValidator : AbstractValidator<CreateSubCategoryCommand>
     {
        public SubCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 20)
                .WithMessage("SubCategory name must be between 3 and 10 characters!");
        }
     }
}
