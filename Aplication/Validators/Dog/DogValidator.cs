using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Dog
{
    public class DogValidator : AbstractValidator<DogDto>
    {       
        public DogValidator()
        {
            RuleFor(dog => dog.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Dog name can not be empty")
            .NotNull().WithMessage("Dog name can not be Null")
            .MinimumLength(2).WithMessage("Dog name must be at least 2 characters")
            .MaximumLength(50).WithMessage("Dog name cannot exceed 50 characters")
            .Must(BeValidName).WithMessage("Name contains invalid characters");
        }
        private bool BeValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
