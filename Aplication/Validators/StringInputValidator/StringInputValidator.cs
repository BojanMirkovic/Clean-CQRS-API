using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.StringInputValidator
{
    public class StringInputValidator : AbstractValidator<string>
    {
        public StringInputValidator()
        {
            RuleFor(input => input)
                .NotEmpty().WithMessage("Data input is required.")
                .MinimumLength(3).WithMessage("Data input must be at least 3 characters")
                .MaximumLength(20).WithMessage("Data input must not exceed 20 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("Data input should contain only letters.");
        }
    }
}
