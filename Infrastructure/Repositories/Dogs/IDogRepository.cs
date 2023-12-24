using Domain.Models.AnimalModel;

namespace Infrastructure.Repositories.Dogs
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogs();
        Task<List<Dog>> GetDogsByBreedAndWeight(string breed, int? weight);
        Task<Dog> GetDogById(Guid id);
        Task<Dog> AddDog(Dog newBird);
        Task<Dog> UpdateDog(Dog updateBird);
        Task<Dog> DeleteDog(Guid id);
    }
}
