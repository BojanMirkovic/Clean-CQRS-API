using MediatR;
using Infrastructure.Database;
using Domain.Models.Animal;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllDogsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Dog>? allDogsFromMockDB = _mockDatabase.Dogs;               
                return Task.FromResult(allDogsFromMockDB);                               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
