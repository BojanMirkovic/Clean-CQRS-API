using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public DeleteBirdByIdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public async Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = await _birdRepository.DeleteBird(request.Id);

            return birdToDelete;
        }
    }
}
