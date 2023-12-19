using Domain.Models.AnimalModel;

namespace Infrastructure.Repositories.Dogs
{
    public interface IDogRepository 
    {
        Task<List<Dog>> GetAllDogs();
        Task<List<Dog>> GetDogsOfSameBreedAndCertainWeight(int weight, string breed);
        Task<Dog> GetDogById(Guid id);
        Task<Dog> AddDog(Dog newBird);
        Task<Dog> UpdateDog(Dog updateBird);
        Task<Dog> DeleteDog(Dog id);
    }
}
