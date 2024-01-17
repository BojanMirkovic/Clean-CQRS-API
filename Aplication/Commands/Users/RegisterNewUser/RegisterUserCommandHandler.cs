using Domain.Models.UserModel;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.RegisterNewUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.NewUser == null || string.IsNullOrEmpty(request.NewUser.UserName) || string.IsNullOrEmpty(request.NewUser.Password))
            {
                throw new ArgumentNullException("Invalid user data. Username and password are required.");
            }

            try
            {
                User userToCreate = new User
                {
                    UserId = Guid.NewGuid(),
                    Username = request.NewUser.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password),
                    Role = "user"
                };

                var createdUser = await _userRepository.RegisterUser(userToCreate);

                return createdUser;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's needs
                throw new ApplicationException("User registration failed.", ex);
            }
        }
    }
}
