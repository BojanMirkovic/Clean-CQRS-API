using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Birds.GetAllBirds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {

        private readonly MockDatabase _mockDatabase;
        public GetAllBirdsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Bird> allBirdsFromMockDB = _mockDatabase.Birds;
                return Task.FromResult(allBirdsFromMockDB);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
