using FluentValidation;
using StudentSystem.Application.DTO;

namespace StudentSystem.Application.Validation.Users;

public class UserForCreationDtoValidator : AbstractValidator<UserForCreationDto>
{
    public UserForCreationDtoValidator()
    {
        RuleFor(user => user)
            .NotNull();

        RuleFor(user => user.firstName)
            .MaximumLength(20)
            .NotEmpty();

        RuleFor(user => user.lastName)
           .MaximumLength(20)
           .NotEmpty();

        RuleFor(user => user.phoneNumber)
            .Matches(@"^\+\d{12}$");

        RuleFor(user => user.email)
            .MaximumLength(100)
            .EmailAddress()
            .NotEmpty();
    }
}