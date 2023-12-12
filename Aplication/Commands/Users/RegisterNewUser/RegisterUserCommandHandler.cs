using Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.RegisterNewUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        Task<User> IRequestHandler<RegisterUserCommand, User>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
