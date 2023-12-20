using Domain.Models.UserModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, User>
    {
       private readonly IUserRepository _userRepository;
        public DeleteUserByIdCommandHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
                User userToDelete = await _userRepository.DeleteUser(request.Id);
                if (userToDelete == null)
                {
                    return null!;
                }

                return userToDelete;
        }
    }
}
