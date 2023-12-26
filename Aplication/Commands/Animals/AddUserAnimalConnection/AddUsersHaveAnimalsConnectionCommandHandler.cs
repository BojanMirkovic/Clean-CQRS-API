using Domain.Models.UserAnimalModel;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Commands.Animals.AddUserAnimalConnection
{
    public class AddUsersHaveAnimalsConnectionCommandHandler : IRequestHandler<AddUsersHaveAnimalsConnectionCommand, UsersHaveAnimals>
    {
        private readonly IAnimalRepository _animalRepository;
        public AddUsersHaveAnimalsConnectionCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public Task<UsersHaveAnimals> Handle(AddUsersHaveAnimalsConnectionCommand request, CancellationToken cancellationToken)
        {
            var connectionToCreate = _animalRepository.AddConnection(request.UserId, request.AnimalId);


            return connectionToCreate;
        }
    }
}
