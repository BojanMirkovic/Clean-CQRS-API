using Application.Commands.Dogs.UpdateDog;
using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    internal class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        MockDatabase _mockDatabase;
        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            if (dogToDelete != null)
            {
                _mockDatabase.Dogs.Remove(dogToDelete);
            }
            return Task.FromResult(dogToDelete)!;
        }
    }
}
