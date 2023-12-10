using Application.Dtos;
using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System.Linq.Expressions;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }


        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find the dog to update
                Dog? dogToUpdate = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id);
                if (dogToUpdate != null)
                {
                    dogToUpdate.Name = request.UpdatedDog.Name;
                    return Task.FromResult(dogToUpdate);
                }

                return Task.FromResult<Dog>(null!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
