using Domain.Models.AnimalModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Birds.GetBirdById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public GetBirdByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Bird wantedBird = _mockDatabase.Birds.Where(bird => bird.AnimalId == request.Id).FirstOrDefault()!;
                if (wantedBird != null)
                {
                    return Task.FromResult(wantedBird);
                }

                return Task.FromResult<Bird>(null!);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
