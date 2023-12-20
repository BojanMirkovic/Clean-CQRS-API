using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;

namespace Application.Commands.Users.RegisterNewUser
{
    public class RegisterUserCommand : IRequest<User>
    {
        public UserDto NewUser { get; }
        public RegisterUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }
    }
}
