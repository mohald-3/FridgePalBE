using Application.Dtos.Items;
using FluentValidation;

namespace Application.Validators.Item
{
    public class ItemDtoValidator : AbstractValidator<ItemDto>
    {
        public ItemDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ExpirationDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("Expiration date must be in the future");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category must be selected");
        }
    }
}
