using Application.HobbyTags.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Validators
{
    public class TagValidator : AbstractValidator<CreateTagCommand>
    {
        public TagValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().Length(3, 10)
                .WithMessage("Category name must be between 5 and 10 characters!");
        }
    }
}
