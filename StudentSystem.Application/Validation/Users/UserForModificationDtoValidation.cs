using FluentValidation;
using StudentSystem.Application.DTO;

namespace StudentSystem.Application.Validation.Users;

public class UserForModificationDtoValidator : AbstractValidator<UserForModificationDto>
{
    public UserForModificationDtoValidator()
    {
        RuleFor(user => user)
            .NotNull();
    }
}
