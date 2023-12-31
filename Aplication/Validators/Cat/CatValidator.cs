﻿using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Cat name can not be empty")
             .NotNull().WithMessage("Cat name can not be Null")
             .MinimumLength(2).WithMessage("Cat name must be at least 2 characters")
             .MaximumLength(50).WithMessage("Cat name cannot exceed 50 characters")
             .Must(BeValidName).WithMessage("Name contains invalid characters");

            RuleFor(cat => cat.LikesToPlay)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Cat name can not be empty")
             .NotNull().WithMessage("Cat name can not be Null")
             .Must(BeValidBoolean).WithMessage("LikesToPlay must be a valid boolean");
            RuleFor(cat => cat.Breed)
                .NotEmpty().WithMessage("Breed is required.")
                .MinimumLength(3).WithMessage("Breed name must be at least 3 characters")
                .MaximumLength(20).WithMessage("Breed name must not exceed 20 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("Breed name should contain only letters.");
            RuleFor(cat => cat.Weight)
                .NotEmpty().WithMessage("Weight is required.")
                .GreaterThanOrEqualTo(1).WithMessage("Weight should be non-negative.")
                .LessThanOrEqualTo(450).WithMessage("Weight should not exceed 450.");


        }
        private bool BeValidBoolean(bool LikesToPlay)
        {
            return LikesToPlay.GetType() == typeof(bool);
        }
        private bool BeValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
