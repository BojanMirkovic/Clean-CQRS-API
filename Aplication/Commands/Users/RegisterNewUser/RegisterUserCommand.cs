using Application.Dtos;
using Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.RegisterNewUser
{
    internal class RegisterUserCommand : IRequest<User>
    {
        public UserDto NewUser { get; }
        public RegisterUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }
    }
}
