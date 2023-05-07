using FluentValidation;
using Game.Contracts.User;

namespace Game.API.Validators;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(u => u.UserName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(256)
            .WithMessage("'{PropertyName}' must not be empty and is limited to 256 characters.");

        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty()
            .MaximumLength(24)
            .WithMessage("'{PropertyName}' must not be empty and is limited to 24 characters.");
    }
}
