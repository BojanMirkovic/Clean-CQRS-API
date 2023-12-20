using Domain.Models.AnimalModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public AddDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Dog dogToCreate = new()
                {
                    AnimalId = Guid.NewGuid(),
                    Name = request.NewDog.Name,
                    Breed = request.NewDog.Breed,
                    Weight = request.NewDog.Weight,
                };

                _mockDatabase.Dogs.Add(dogToCreate);
                return Task.FromResult(dogToCreate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
