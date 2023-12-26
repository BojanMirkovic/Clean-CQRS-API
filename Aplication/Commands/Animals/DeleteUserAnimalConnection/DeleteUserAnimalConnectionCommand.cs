using Domain.Models.UserAnimalModel;
using MediatR;

namespace Application.Commands.Animals.DeleteUserAnimalConnection
{
    public class DeleteUserAnimalConnectionCommand : IRequest<UsersHaveAnimals>
    {
        public Guid UserId { get; }
        public Guid AnimalId { get; }
        public DeleteUserAnimalConnectionCommand(Guid userId, Guid animalId)
        {
            UserId = userId;
            AnimalId = animalId;
        }
    }
}
