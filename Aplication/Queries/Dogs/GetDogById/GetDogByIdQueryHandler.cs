using MediatR;
using Infrastructure.Database;
using Domain.Models.AnimalModel;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public GetDogByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Dog? wantedDog = _mockDatabase.Dogs.Where(Dog => Dog.AnimalId == request.Id).FirstOrDefault()!;

                if (wantedDog != null)
                {
                    return Task.FromResult(wantedDog);
                }

                return Task.FromResult<Dog>(null!);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
