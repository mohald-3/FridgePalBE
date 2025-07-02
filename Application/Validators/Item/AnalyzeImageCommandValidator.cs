using Application.Commands.Items.RecognizeItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Item
{
    public class AnalyzeImageCommandValidator : AbstractValidator<AnalyzeImageCommand>
    {
        public AnalyzeImageCommandValidator()
        {
            RuleFor(x => x.Image)
                .NotNull().WithMessage("Image is required.")
                .Must(f => f.Length > 0).WithMessage("Image file is empty.");
        }
    }
}
