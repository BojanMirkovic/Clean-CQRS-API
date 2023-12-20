using Domain.Models.UserModel;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<User>
    {
        public Guid Id { get; }
        public DeleteUserByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
