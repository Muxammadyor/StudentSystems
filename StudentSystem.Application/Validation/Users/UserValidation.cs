using FluentValidation;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Validation.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty();
    }
}
