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
        Task<User> IRequestHandler<RegisterUserCommand, User>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password),
                Authorized = true,
                Role = "admin"
            };

            _mockDatabase.Users.Add(userToCreate);

            return Task.FromResult(userToCreate);
        }
    }
}
