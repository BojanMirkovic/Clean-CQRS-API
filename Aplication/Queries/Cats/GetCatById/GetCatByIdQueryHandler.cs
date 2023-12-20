using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetCatById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly ICatRepository _catRepository;    
        public GetCatByIdQueryHandler(ICatRepository catRepository) 
        { 
            _catRepository = catRepository;
        }
        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Cat wantedCat = await _catRepository.GetCatById(request.Id);
                if (wantedCat == null)
                {
                    return null!;
                }

                return wantedCat;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
