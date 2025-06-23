using Application.Dtos.Items;
using FluentValidation;

namespace Application.Validators.Item
{
    public class AddItemDtoValidator : AbstractValidator<AddItemDto>
    {
        public AddItemDtoValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty().WithMessage("Item name is required")
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1");

            RuleFor(x => x.ExpirationDate)
                .Must(date => date > DateTime.UtcNow)
                .WithMessage("Expiration date must be in the future");

            RuleFor(x => x.Category)
                .GreaterThan(0).WithMessage("Category is required");
        }
    }
}
