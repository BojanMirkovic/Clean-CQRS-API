using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.InputIntValidator
{
    public class IntInputValidator : AbstractValidator<int>
    {
        public IntInputValidator() 
        {
            RuleFor(input => input)
                 .NotEmpty().WithMessage("Data input is required.")
                 .GreaterThanOrEqualTo(1).WithMessage("Data input should be non-negative.")
                 .LessThanOrEqualTo(450).WithMessage("Data input should not exceed 450.");
        }
    }
}
