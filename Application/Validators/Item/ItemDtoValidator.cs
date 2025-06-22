using Application.Dtos.Items;
using FluentValidation;

namespace Application.Validators.Item
{
    public class ItemDtoValidator : AbstractValidator<ItemDto>
    {
        public ItemDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
