using FluentValidation;

namespace Sample.Application.DTOs.Validation
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(p => p.UserName)
               .NotNull()
               .MaximumLength(20).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.FirstName)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.LastName)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.UserName).Matches(@"(0|\+98)([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}").WithMessage("Please provide valid phone number");
        }
    }
}
