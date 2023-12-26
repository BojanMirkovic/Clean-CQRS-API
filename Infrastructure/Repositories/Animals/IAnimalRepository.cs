using Domain.Models.AnimalModel;
using Domain.Models.UserAnimalModel;

namespace Infrastructure.Repositories.Animals
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> GetAllAnimals();
 
        Task<List<UserAnimalData>> GetAllAnimalsByUserId(Guid id);
        Task<Animal> GetAnimalById(Guid id);
        Task<UsersHaveAnimals> AddConnection(Guid userId, Guid animalId);
        Task<UsersHaveAnimals> DeleteConnection(Guid userId, Guid animalId);
        // New method to retrieve user-animal relationships by UserId
        Task<List<UsersHaveAnimals>> GetUsersHaveAnimalsByUserId(Guid userId);
    }
}
