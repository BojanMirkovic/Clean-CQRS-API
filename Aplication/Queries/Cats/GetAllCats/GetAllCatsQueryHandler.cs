using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetAllCats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;
        public GetAllCatsQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
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

                throw new Exception(ex.Message);
            }
        }
    }
}
