using Domain.Models.AnimalModel;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public AddBirdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Bird birdToCreate = new()
                {
                    AnimalId = new Guid(),
                    Name = request.NewBird.Name,
                    CanFly = request.NewBird.CanFly,
                    Color = request.NewBird.Color
                };

                _mockDatabase.Birds.Add(birdToCreate);
                return Task.FromResult(birdToCreate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
