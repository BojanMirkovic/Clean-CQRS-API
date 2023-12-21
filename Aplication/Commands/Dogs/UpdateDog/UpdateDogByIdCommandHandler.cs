using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Dogs;
using MediatR;


namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public UpdateDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            // Find the dog to update
            Dog dogToUpdate = await _dogRepository.GetDogById(request.Id);
            if (dogToUpdate == null)
            {
                return null!;
            }

            dogToUpdate.Name = request.UpdatedDtoDog.Name;
            dogToUpdate.Breed = request.UpdatedDtoDog.Breed;
            dogToUpdate.Weight = request.UpdatedDtoDog.Weight;

            var updatedDog = await _dogRepository.UpdateDog(dogToUpdate);

            return updatedDog;
        }
    }
}
