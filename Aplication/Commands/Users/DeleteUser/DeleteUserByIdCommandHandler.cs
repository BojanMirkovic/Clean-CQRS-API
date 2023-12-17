﻿using Domain.Models.Animal;
using Domain.Models.User;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, User>
    {
        MockDatabase _mockDatabase;
        public DeleteUserByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User? userToDelete = _mockDatabase.Users.FirstOrDefault(cat => cat.Id == request.Id)!;
                if (userToDelete != null)
                {
                    _mockDatabase.Users.Remove(userToDelete);
                    return Task.FromResult(userToDelete)!;
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