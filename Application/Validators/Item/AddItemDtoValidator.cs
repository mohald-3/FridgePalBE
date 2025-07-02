using Application.Dtos.Items;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Item
{
    public class AddItemDtoValidator : AbstractValidator<ItemWithImageDto>
    {
        public AddItemDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ExpirationDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Expiration date must be in the future");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category must be selected");

        }
    }
}
