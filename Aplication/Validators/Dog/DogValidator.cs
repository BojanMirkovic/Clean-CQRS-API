using Application.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using System.Data;

namespace Application.Validators.Dog
{
    public class DogValidator : AbstractValidator<DogDto>
    {
      public DogValidator() 
      {
            RuleFor(dog => dog.Name)
            .NotEmpty().WithMessage("Dog name can not be empty")
            .NotNull().WithMessage("Dog name can not be Null")
            .MinimumLength(2).WithMessage("Dog name must be at least 2 characters")
            .MaximumLength(50).WithMessage("Dog name cannot exceed 50 characters");
      }
    }
}
