using Application.Hobby.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Validators
{
    public class HobbyArticleValidator : AbstractValidator<CreateHobbyCommand>
    {
        public HobbyArticleValidator()
        {

            RuleFor(hobby => hobby.Tags).NotNull()
                .WithMessage("Tag list must contain at least one tag");

            RuleFor(hobby => hobby.Description).NotEmpty().Length(5, 100)
                .WithMessage("Description can not be empty and must be more than 5 characters");

        }
    }
}
