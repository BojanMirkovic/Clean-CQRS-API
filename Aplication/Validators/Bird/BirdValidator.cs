using Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Bird
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {
        public BirdValidator()
        {
            RuleFor(bird => bird.Name)
               .NotEmpty().WithMessage("Bird name can not be empty")
               .NotNull().WithMessage("Bird name can not be Null")
               .MinimumLength(2).WithMessage("Bird name must be at least 2 characters")
               .MaximumLength(50).WithMessage("Bird name cannot exceed 50 characters");

            RuleFor(bird => bird.CanFly)
               .NotEmpty().WithMessage("Bird name can not be empty")
               .NotNull().WithMessage("Bird name can not be Null")
               .Must(BeValidBoolean).WithMessage("CanFly must be a valid boolean");
        }
        private bool BeValidBoolean(bool canFly)
        {
            return canFly.GetType() == typeof(bool);
        }
    }
}
