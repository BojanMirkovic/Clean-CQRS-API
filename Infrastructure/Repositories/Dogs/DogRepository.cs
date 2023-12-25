using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDb _sqlDatabase;

        public DogRepository(RealDb sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }

        public async Task<Dog> AddDog(Dog newDog)
        {
            try
            {
                _sqlDatabase.Dogs.Add(newDog);
                _sqlDatabase.SaveChanges();
                return await Task.FromResult(newDog);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Dog> DeleteDog(Guid id)
        {
            try
            {
                Dog dogToDelete = await GetDogById(id);

                _sqlDatabase.Dogs.Remove(dogToDelete);

                _sqlDatabase.SaveChanges();

                return await Task.FromResult(dogToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a dog with Id {id} from the database", ex);
            }
        }

        public async Task<List<Dog>> GetAllDogs()
        {
            try
            {
                return await _sqlDatabase.Dogs.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all dogs from the database", ex);
            }
        }

        public async Task<Dog> GetDogById(Guid id)
        {
            try
            {
                Dog? wantedDog = await _sqlDatabase.Dogs.FirstOrDefaultAsync(dog => dog.AnimalId == id);

                if (wantedDog == null)
                {
                    throw new Exception($"There was no dog with Id {id} in the database");
                }

                return await Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a dog with Id {id} from database", ex);
            }
        }

        public async Task<List<Dog>> GetDogsByBreedAndWeight(string breed, int? weight)
        {
            try
            {
                var dogsQuery = _sqlDatabase.Dogs.AsQueryable();

                if (!string.IsNullOrEmpty(breed))
                {
                    dogsQuery = dogsQuery.Where(dog => dog.Breed == breed);
                }

                if (weight.HasValue)
                {
                    dogsQuery = dogsQuery.Where(dog => dog.Weight >= weight);
                }

                var dogs = await dogsQuery.OrderByDescending(dog => dog.Weight).ToListAsync();

                return dogs;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while getting cats of {breed} breed and weight from the database", ex);
            }
        }


        public Task<Dog> UpdateDog(Dog updateDog)
        {
            try
            {
                _sqlDatabase.Dogs.Update(updateDog);

                _sqlDatabase.SaveChanges();

                return Task.FromResult(updateDog);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a dog by Id {updateDog.AnimalId} from database", ex);
            }
        }
    }
}
