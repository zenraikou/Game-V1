using FluentValidation;
using Game.Contracts.Items;

namespace Game.API.Validators;

public class ItemRequestValidator : AbstractValidator<ItemRequest>
{
    public ItemRequestValidator()
    {
        RuleFor(i => i.Name)
            .Length(1, 24)
            .WithMessage("'{PropertyName}' must not be empty and is limited to 24 characters.");

        RuleFor(i => i.Description)
            .Length(1, 60)
            .WithMessage("'{PropertyName}' must not be empty and is limited to 60 characters.");
    }
}