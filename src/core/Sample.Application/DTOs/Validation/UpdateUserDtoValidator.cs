using FluentValidation;

namespace Sample.Application.DTOs.Validation
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            Include(new UserDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
