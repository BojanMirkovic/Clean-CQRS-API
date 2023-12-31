using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Cats;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Cats.GetAllCats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<GetAllCatsQueryHandler> _logger;
        public GetAllCatsQueryHandler(ICatRepository catRepository, ILogger<GetAllCatsQueryHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }
        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Cat> allCatsFromDB = await _catRepository.GetAllCats();
                return allCatsFromDB;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all cats");
                throw;
            }
        }
    }
}
