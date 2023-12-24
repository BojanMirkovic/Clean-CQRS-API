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
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Bird name can not be empty")
               .NotNull().WithMessage("Bird name can not be Null")
               .MinimumLength(2).WithMessage("Bird name must be at least 2 characters")
               .MaximumLength(50).WithMessage("Bird name cannot exceed 50 characters")
               .Must(BeValidName).WithMessage("Name contains invalid characters");

            RuleFor(bird => bird.CanFly)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Bird name can not be empty")
               .NotNull().WithMessage("Bird name can not be Null")
               .Must(BeValidBoolean).WithMessage("CanFly must be a valid boolean");
            RuleFor(bird => bird.Color)
               .NotEmpty().WithMessage("Color is required.")
               .MinimumLength(3).WithMessage("Bird name must be at least 3 characters")
               .MaximumLength(20).WithMessage("Color must not exceed 20 characters.")
               .Matches("^[a-zA-Z]+$").WithMessage("Color should contain only letters."); 

        }
        private bool BeValidBoolean(bool canFly)
        {
            return canFly.GetType() == typeof(bool);
        }
        private bool BeValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
