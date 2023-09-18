using FluentValidation;

namespace Sample.Application.DTOs.Validation
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            Include(new UserDtoValidator());

        }
    }
}
