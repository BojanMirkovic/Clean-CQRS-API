using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdInfoByIdCommandHandler : IRequestHandler<UpdateBirdInfoByIdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public UpdateBirdInfoByIdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public async Task<Bird> Handle(UpdateBirdInfoByIdCommand request, CancellationToken cancellationToken)
        {
                Bird birdToUpdate = await _birdRepository.GetBirdById(request.Id);
                if (birdToUpdate == null)
                {
                    return null!;
                }

                birdToUpdate.Name = request.UpdatedBird.Name;
                birdToUpdate.CanFly = request.UpdatedBird.CanFly;
                birdToUpdate.Color = request.UpdatedBird.Color;


                var updatedBird = await _birdRepository.UpdateBird(birdToUpdate);

                return updatedBird;
        }
    }
}
