using Domain.Models.AnimalModel;
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
            try
            {
                Cat? wantedCat = _mockDatabase.Cats.Where(cat => cat.AnimalId == request.Id).FirstOrDefault()!;
                if (wantedCat != null)
                {
                    return Task.FromResult(wantedCat);
                }

                return Task.FromResult<Cat>(null!);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
