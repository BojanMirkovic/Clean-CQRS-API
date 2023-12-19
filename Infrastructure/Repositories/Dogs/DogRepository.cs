using Domain.Models.AnimalModel;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Dogs
{
    public class DogRepository : IDogRepository
    {

        //return _context.Dogs
        //    .Where(d => d.Breed == breed)
        //    .Where(d => d.Weight == weight)
        //    .OrderByDescending(d => d.Weight)
        //    .ToList();
        public Task<Dog> AddDog(Dog newBird)
        {
            throw new NotImplementedException();
        }

        public Task<Dog> DeleteDog(Dog id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dog>> GetAllDogs()
        {
            throw new NotImplementedException();
        }

        public Task<Dog> GetDogById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dog>> GetDogsOfSameBreedAndCertainWeight(int weight, string breed)
        {
            throw new NotImplementedException();
        }

        public Task<Dog> UpdateDog(Dog updateBird)
        {
            throw new NotImplementedException();
        }
    }
}
