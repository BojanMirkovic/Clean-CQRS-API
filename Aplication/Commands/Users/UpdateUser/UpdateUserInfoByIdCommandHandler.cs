using Domain.Models.Animal;
using Domain.Models.User;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserInfoByIdCommandHandler : IRequestHandler<UpdateUserInfoByIdCommand, User>
    {
        private readonly MockDatabase _mockDatabase;
        public UpdateUserInfoByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }

        public Task<User> Handle(UpdateUserInfoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User? userToUpdate = _mockDatabase.Users.FirstOrDefault(user => user.Id == request.Id)!;
                User? userToUpdate = _mockDatabase.Users.Where(user => user.Id == request.Id).FirstOrDefault()!;
                if (userToUpdate != null)
                {
                    userToUpdate.Username = request.UpdatedUser.UserName;
                    userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(request.UpdatedUser.Password);
                    userToUpdate.Role = request.UpdatedUser.Role;

                    return Task.FromResult(userToUpdate);
                }

                return Task.FromResult<User>(null!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
