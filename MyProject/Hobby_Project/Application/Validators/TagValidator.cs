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
            RuleFor(x => x).NotNull().WithMessage("Category...");

            RuleFor(x=>x.Name).NotNull().NotEmpty().Length(3, 10)
                .WithMessage("Tag name must be between 3 and 10 characters!");
            
        }
    }
}
