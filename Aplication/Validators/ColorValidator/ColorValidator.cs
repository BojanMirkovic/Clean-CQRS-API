using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ColorValidator
{
    public class ColorValidator : AbstractValidator<string>
    {
        public ColorValidator() 
        {
            RuleFor(color => color)
                .NotEmpty().WithMessage("Color is required.")
                .MinimumLength(3).WithMessage("Bird name must be at least 3 characters")
                .MaximumLength(20).WithMessage("Color must not exceed 20 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("Color should contain only letters.");
        }
    }
}
