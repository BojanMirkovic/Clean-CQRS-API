using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdInfoByIdCommandHandler : IRequestHandler<UpdateBirdInfoByIdCommand, Bird>
    {
        public readonly MockDatabase _mockDatabase;
        public UpdateBirdInfoByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(UpdateBirdInfoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Bird? birdToUpdate = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id)!;
                if (birdToUpdate != null) 
                {
                    birdToUpdate.Name = request.UpdatedBird.Name;
                    birdToUpdate.CanFly = request.UpdatedBird.CanFly;

                    return Task.FromResult(birdToUpdate);
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
