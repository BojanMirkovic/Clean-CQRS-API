using Domain.Models.Animal;
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
            Cat catToCreate = new()
            {
                Id = new Guid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay,
            };
            _mockDatabase.Cats.Add(catToCreate);
            return Task.FromResult(catToCreate);
        }
    }
}
