using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetAllCatsByBreedAndWeight
{
    public class GetCatsByBreedAndWeightQueryHandler : IRequestHandler<GetCatsByBreedAndWeightQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;

        public GetCatsByBreedAndWeightQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> Handle(GetCatsByBreedAndWeightQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsByBreedAndWeightFromDB = await _catRepository.GetCatsByBreedAndWeight(request.Breed, request.Weight);

            return allCatsByBreedAndWeightFromDB;
        }
    }
}
