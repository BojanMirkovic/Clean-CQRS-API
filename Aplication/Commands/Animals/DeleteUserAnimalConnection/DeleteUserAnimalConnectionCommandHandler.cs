using Application.Commands.Animals.AddUserAnimalConnection;
using Domain.Models.UserAnimalModel;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Commands.Animals.DeleteUserAnimalConnection
{
    public class DeleteUserAnimalConnectionCommandHandler : IRequestHandler<DeleteUserAnimalConnectionCommand, UsersHaveAnimals>
    {

        private readonly IAnimalRepository _animalRepository;

        public DeleteUserAnimalConnectionCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Task<UsersHaveAnimals> Handle(DeleteUserAnimalConnectionCommand request, CancellationToken cancellationToken)
        {
            var connectionToDelete = _animalRepository.DeleteConnection(request.UserId, request.AnimalId);

            return connectionToDelete;
        }
    }
}
