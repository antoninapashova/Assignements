using Application.Users.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Validators
{
    public class UserValidator : AbstractValidator<CreateUserCommand>
    {
        public UserValidator()
        {
            RuleFor(x=>x.Username).NotNull().NotEmpty().Length(5, 10)
                .WithMessage("Username must be between 5 and 10 characters!");

            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 10)
                .WithMessage("First name must be between 3 and 10 characters!");

            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 10)
                .WithMessage("Last name must be between 3 and 10 characters");

            RuleFor(x => x.Email).NotNull().NotEmpty()
                .WithMessage("Email can not be empty!")
                .EmailAddress();

            RuleFor(x => x.Age).InclusiveBetween(14, 60);

            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password can not be empty!")
                .MinimumLength(5).WithMessage("Password must be at least 5 characters!");

        }
    }
}
