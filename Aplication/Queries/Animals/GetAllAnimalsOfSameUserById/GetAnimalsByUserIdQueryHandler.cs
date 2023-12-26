using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Queries.Animals.GetAllAnimalsOfSameUserById
{
    public class GetAnimalsByUserIdQueryHandler : IRequestHandler<GetAnimalsByUserIdQuery, List<UserAnimalData>>
    {
        private readonly IAnimalRepository _repository;
        public GetAnimalsByUserIdQueryHandler(IAnimalRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<UserAnimalData>> Handle(GetAnimalsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAnimalsByUserId(request.UserId);
        }
    }
}
