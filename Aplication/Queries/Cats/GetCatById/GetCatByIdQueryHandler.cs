using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Cats.GetCatById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public GetCatByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _mockDatabase.Cats.Where(cat => cat.Id == request.Id).FirstOrDefault()!;

            return Task.FromResult(wantedCat);
        }
    }
}
