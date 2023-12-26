using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Animals;
using MediatR;


namespace Application.Queries.Animals.GetAnimalById
{
    public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQuery, Animal>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAnimalByIdQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<Animal> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
        {
            Animal wantedAnimal = await _animalRepository.GetAnimalById(request.Id);
            if (wantedAnimal == null)
            {
                return null!;
            }

            return wantedAnimal;
        }
    }
}
