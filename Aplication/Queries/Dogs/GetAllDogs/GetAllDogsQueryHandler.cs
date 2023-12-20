using MediatR;
using Infrastructure.Database;
using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Dogs;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;
        public GetAllDogsQueryHandler(IDogRepository dogRepository) 
        {
            _dogRepository = dogRepository;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {    
                List<Dog> allDogsFromDB = await _dogRepository.GetAllDogs();
                return allDogsFromDB;           
        }
    }
}
