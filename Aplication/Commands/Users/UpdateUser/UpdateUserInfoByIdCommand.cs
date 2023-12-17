using Application.Dtos;
using Domain.Models.User;
using MediatR;


namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserInfoByIdCommand : IRequest<User>
    {
        public UpdateUserInfoByIdCommand(UserUpdateDto updatedUser, Guid id)
        {
            UpdatedUser = updatedUser;
            Id = id;
        }

        public UserUpdateDto UpdatedUser { get; }
        public Guid Id { get; }
    }
}
