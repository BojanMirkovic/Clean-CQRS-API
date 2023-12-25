using Application.Queries.Dogs.GetCatsByBreedAndWeight;
using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Dogs;
using MediatR;


namespace Application.Queries.Dogs.GetDogsByBreedAndWeight
{
    public class GetDogsByBreedAndWeightQueryHandler : IRequestHandler<GetDogsByBreedAndWeightQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetDogsByBreedAndWeightQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<List<Dog>> Handle(GetDogsByBreedAndWeightQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsByBreedAndWeightFromDB = await _dogRepository.GetDogsByBreedAndWeight(request.Breed, request.Weight);

            return allDogsByBreedAndWeightFromDB;
        }
    }
}
