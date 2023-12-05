using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name)
             .NotEmpty().WithMessage("Cat name can not be empty")
             .NotNull().WithMessage("Cat name can not be Null")
             .MinimumLength(2).WithMessage("Cat name must be at least 2 characters")
             .MaximumLength(50).WithMessage("Cat name cannot exceed 50 characters");

            RuleFor(cat => cat.LikesToPlay)
             .NotEmpty().WithMessage("Cat name can not be empty")
             .NotNull().WithMessage("Cat name can not be Null")
             .Must(BeValidBoolean).WithMessage("LikesToPlay must be a valid boolean");
        }
        private bool BeValidBoolean(bool LikesToPlay)
        {
            return LikesToPlay.GetType() == typeof(bool);
        }
    }
}
