using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public AddDogCommandHandler(IDogRepository dogRepository) 
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
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

                var createdDog = await _dogRepository.AddDog(dogToCreate);
                return createdDog;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
