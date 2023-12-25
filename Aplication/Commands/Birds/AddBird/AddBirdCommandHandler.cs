using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public AddBirdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
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

                //_birdRepository.AddBird(birdToCreate);
                //return Task.FromResult(birdToCreate);
                await _birdRepository.AddBird(birdToCreate);
                return birdToCreate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
