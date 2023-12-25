using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;


namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserInfoByIdCommand : IRequest<User>
    {
        public UpdateUserInfoByIdCommand(UpdatingUserDto updatedUser, Guid id)
        {
            UpdatedUser = updatedUser;
            Id = id;
        }

        public UpdatingUserDto UpdatedUser { get; }
        public Guid Id { get; }
    }
}
