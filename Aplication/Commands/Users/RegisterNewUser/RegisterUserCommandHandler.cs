using BCrypt.Net;
using Domain.Models.User;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.RegisterNewUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly MockDatabase _mockDatabase;
        public RegisterUserCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.NewUser == null || string.IsNullOrEmpty(request.NewUser.UserName) || string.IsNullOrEmpty(request.NewUser.Password))
            {
                throw new ArgumentNullException("Invalid user data. Username and password are required.");
            }

            try
            {
                User userToCreate = new User
                {
                    Id = Guid.NewGuid(),
                    Username = request.NewUser.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password),
                    Role = "user"
                };

                _mockDatabase.Users.Add(userToCreate);

                return Task.FromResult(userToCreate);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's needs
                throw new ApplicationException("User registration failed.", ex);
            }
        }
    }
}
