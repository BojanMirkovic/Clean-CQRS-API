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
            RuleFor(dog => dog.Breed)
               .NotEmpty().WithMessage("Breed is required.")
               .MinimumLength(3).WithMessage("Breed name must be at least 3 characters")
               .MaximumLength(20).WithMessage("Breed name must not exceed 20 characters.")
               .Matches("^[a-zA-Z]+$").WithMessage("Breed name should contain only letters.");
            RuleFor(dog => dog.Weight)
                .NotEmpty().WithMessage("Weight is required.")
                .GreaterThanOrEqualTo(1).WithMessage("Weight should be non-negative.")
                .LessThanOrEqualTo(150).WithMessage("Weight should not exceed 150.");
        }
        private bool BeValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
