using Application.Dtos.Categories;
using FluentValidation;

namespace Application.Validators.Category
{
    public class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(50).WithMessage("Category name can't exceed 50 characters");

            // Prevents duplicates
            //RuleFor(x => x.CategoryName)
            //  .MustAsync(BeUniqueCategoryName).WithMessage("Category name already exists");
        }
    }
}
