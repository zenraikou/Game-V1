using FluentValidation;
using Game.Contracts.Item;

namespace Game.API.Validators;

public class ItemRequestValidator : AbstractValidator<ItemRequest>
{
    public ItemRequestValidator()
    {
        RuleFor(i => i.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(24)
            .WithMessage("'{PropertyName}' must not be empty and is limited to 24 characters.");

        RuleFor(i => i.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(60)
            .WithMessage("'{PropertyName}' must not be empty and is limited to 60 characters.");
    }
}
