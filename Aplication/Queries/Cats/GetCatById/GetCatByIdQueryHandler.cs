using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Cats.GetCatById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<GetCatByIdQueryHandler> _logger;
        public GetCatByIdQueryHandler(ICatRepository catRepository, ILogger<GetCatByIdQueryHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }
        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Cat wantedCat = await _catRepository.GetCatById(request.Id);
                if (wantedCat == null)
                {
                    //return null!;
                    _logger.LogWarning("Cat not found: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }

                return wantedCat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
