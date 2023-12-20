using Domain.Models.UserModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserInfoByIdCommandHandler : IRequestHandler<UpdateUserInfoByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserInfoByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserInfoByIdCommand request, CancellationToken cancellationToken)
        {
                User userToUpdate = await _userRepository.GetUserById(request.Id);
                if (userToUpdate == null)
                {
                  return null!;
                }

            userToUpdate.Username = request.UpdatedUser.UserName;
            userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(request.UpdatedUser.Password);
            userToUpdate.Role = request.UpdatedUser.Role;

            var updatedUser= await _userRepository.UpdateUser(userToUpdate);

            return updatedUser;
        }
    }
}
