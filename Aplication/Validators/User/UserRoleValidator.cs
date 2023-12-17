using Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class UserRoleValidator : AbstractValidator<UserUpdateDto>
    {
        public UserRoleValidator()
        {
            RuleFor(user => user.Role)
               .NotEmpty().WithMessage("Role is required.")
               .Must(role => role == "admin" || role == "user").WithMessage("Role must be either 'admin' or 'user'.");
        }
    }
}
