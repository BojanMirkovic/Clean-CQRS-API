using MediatR;
using Infrastructure.Database;
using Domain.Models.AnimalModel;
using Infrastructure.Repositories.Dogs;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public GetDogByIdQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = await _dogRepository.GetDogById(request.Id);

            if (wantedDog == null)
            {
                return null!;
            }

            return wantedDog;
        }
    }
}
