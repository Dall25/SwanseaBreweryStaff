using FluentValidation;
using Models.Entities;

namespace Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("Please enter first name");
            RuleFor(user => user.LastName).NotNull().NotEmpty().WithMessage("Please enter last name");
        }

    }
}
