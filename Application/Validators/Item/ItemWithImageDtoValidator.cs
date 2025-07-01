﻿using Application.Dtos.Items;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Item
{
    public class ItemWithImageDtoValidator : AbstractValidator<ItemWithImageDto>
    {
        public ItemWithImageDtoValidator()
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

            // Optional: add image validation if needed
            // RuleFor(x => x.Image)
            //     .NotNull().WithMessage("Image file is required");
        }
    }
}
