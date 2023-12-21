using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public DeleteDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = await _dogRepository.DeleteDog(request.Id);
            if (dogToDelete == null)
            {
                return null!;
            }
            return dogToDelete;
        }
    }
}
