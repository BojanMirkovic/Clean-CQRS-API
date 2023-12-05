using Application.Dtos;
using Domain.Models.Animal;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.GuidValidator
{
    public class GuidValidator : AbstractValidator<Guid>
    {
       public GuidValidator() 
        {
            RuleFor(guid => guid)
               .NotEmpty().WithMessage("Guid should not be empty")
               .NotNull().WithMessage("Guid should not be the empty Guid");
               
        }
    }
}
