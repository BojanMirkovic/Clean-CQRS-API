using FluentValidation;

namespace Application.Validators.GuidValidator
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid)
               .NotEmpty().WithMessage("Guid should not be empty")
               .NotEqual(Guid.Empty).WithMessage("Guid should not be the empty Guid");
        }
    }
}
