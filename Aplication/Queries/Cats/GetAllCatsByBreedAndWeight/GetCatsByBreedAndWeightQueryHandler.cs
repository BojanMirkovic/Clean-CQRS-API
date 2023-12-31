using Application.Queries.Cats.GetCatById;
using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Cats.GetAllCatsByBreedAndWeight
{
    public class GetCatsByBreedAndWeightQueryHandler : IRequestHandler<GetCatsByBreedAndWeightQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<GetCatsByBreedAndWeightQueryHandler> _logger;

        public GetCatsByBreedAndWeightQueryHandler(ICatRepository catRepository, ILogger<GetCatsByBreedAndWeightQueryHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public async Task<List<Cat>> Handle(GetCatsByBreedAndWeightQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Cat> allCatsByBreedAndWeightFromDB = await _catRepository.GetCatsByBreedAndWeight(request.Breed, request.Weight);
                if (allCatsByBreedAndWeightFromDB == null)
                {
                    //return null!;
                    _logger.LogWarning($"Cat data not found: CatBreed {request.Breed},CatWeight {request.Weight}.");
                    throw new KeyNotFoundException($"Cat with Breed = {request.Breed}, Weight = {request.Weight}  was not found.");
                }

                return allCatsByBreedAndWeightFromDB;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Error occurred while retrieving cat info: CatBreed {request.Breed}, CatWeight {request.Weight}");
                throw;
            }
        }
    }
}
