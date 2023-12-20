using Domain.Models.AnimalModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatInfoByIdCommandHandler : IRequestHandler<UpdateCatInfoByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateCatInfoByIdCommandHandler(MockDatabase mockDatabase)
        { _mockDatabase = mockDatabase; }
        public Task<Cat> Handle(UpdateCatInfoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat? catToUpdate = _mockDatabase.Cats.FirstOrDefault(cat => cat.AnimalId == request.Id)!;
                if (catToUpdate != null)
                {
                    catToUpdate.Name = request.UpdatedCat.Name;
                    catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
                    catToUpdate.Breed = request.UpdatedCat.Breed;
                    catToUpdate.Weight = request.UpdatedCat.Weight;

                    return Task.FromResult(catToUpdate);
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
