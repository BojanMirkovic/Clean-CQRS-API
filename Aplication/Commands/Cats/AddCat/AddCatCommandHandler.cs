using Domain.Models.AnimalModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public AddCatCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToCreate = new()
                {
                    AnimalId = new Guid(),
                    Name = request.NewCat.Name,
                    Breed = request.NewCat.Breed,
                    Weight = request.NewCat.Weight,
                    LikesToPlay = request.NewCat.LikesToPlay,
                };
                _mockDatabase.Cats.Add(catToCreate);
                return Task.FromResult(catToCreate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
