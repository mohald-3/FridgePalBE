using Application.Dtos.Items;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Item
{
    public class UpdateItemPartialDtoValidator : AbstractValidator<UpdateItemPartialDto>
    {
        public UpdateItemPartialDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100)
                .When(x => x.ProductName != null);

            RuleFor(x => x.Quantity.Value)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0")
                .When(x => x.Quantity.HasValue);

            RuleFor(x => x.ExpirationDate.Value)
                .GreaterThan(DateTime.UtcNow).WithMessage("Expiration date must be in the future")
                .When(x => x.ExpirationDate.HasValue);

            RuleFor(x => x.CategoryId.Value)
                .GreaterThan(0).WithMessage("Invalid category ID")
                .When(x => x.CategoryId.HasValue);
        }
    }
}
