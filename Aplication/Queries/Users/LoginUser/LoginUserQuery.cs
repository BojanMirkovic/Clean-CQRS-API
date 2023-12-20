using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;

namespace Application.Queries.Users.LoginUser
{
    public class LoginUserQuery : IRequest<string>
    {
        public UserDto LoginUser { get; }
        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }
    }
}
