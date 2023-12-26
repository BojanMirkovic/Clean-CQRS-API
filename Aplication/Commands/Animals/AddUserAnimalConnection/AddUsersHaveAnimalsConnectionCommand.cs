using Domain.Models.UserAnimalModel;
using MediatR;

namespace Application.Commands.Animals.AddUserAnimalConnection
{
    public class AddUsersHaveAnimalsConnectionCommand : IRequest<UsersHaveAnimals>
    {
        public Guid UserId { get; }
        public Guid AnimalId { get; }
        public AddUsersHaveAnimalsConnectionCommand(Guid userId, Guid animalId)
        {
            UserId = userId;
            AnimalId = animalId;
        }
    }
}

