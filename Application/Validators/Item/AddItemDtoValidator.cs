using Application.Dtos.Items;
using FluentValidation;

namespace Application.Validators.Item
{
    public class AddItemDtoValidator : AbstractValidator<ItemDto>
    {
        public AddItemDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ExpirationDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date).WithMessage("Expiration date must be in the future");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category must be selected");

        }
    }
}
