using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Animals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Animals.GetAllAnimals
{
    public class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, List<Animal>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<List<Animal>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
        {
            List<Animal> allAnimals = await _animalRepository.GetAllAnimals();

            return allAnimals;
        }
    }
}
