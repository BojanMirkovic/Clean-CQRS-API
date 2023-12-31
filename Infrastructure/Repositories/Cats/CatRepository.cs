using Domain.Models.AnimalModel;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Cats
{
    public class CatRepository : ICatRepository
    {

        private readonly RealDb _sqlDatabase;

        public CatRepository(RealDb sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
        }


        public async Task<Cat> AddCat(Cat newCat)
        {
            try
            {
                _sqlDatabase.Cats.Add(newCat);
                _sqlDatabase.SaveChanges();
                return await Task.FromResult(newCat);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Cat> DeleteCat(Guid id)
        {
            try
            {
                Cat catToDelete = await GetCatById(id);

                _sqlDatabase.Cats.Remove(catToDelete);

                _sqlDatabase.SaveChanges();

                return await Task.FromResult(catToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a cat with Id {id} from the database", ex);
            }
        }
        public async Task<List<Cat>> GetAllCats()
        {
            try
            {
                return await _sqlDatabase.Cats.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all cats from the database", ex);
            }
        }

        public async Task<Cat> GetCatById(Guid id)
        {
            try
            {
                Cat? wantedBird = await _sqlDatabase.Cats.FirstOrDefaultAsync(cat => cat.AnimalId == id);

                if (wantedBird == null)
                {
                    throw new Exception($"There was no cat with Id {id} in the database");
                }

                return await Task.FromResult(wantedBird);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a cat with Id {id} from database", ex);
            }
        }

        public async Task<List<Cat>> GetCatsByBreedAndWeight(string breed, int? weight)
        {
            try
            {
                var catsQuery = _sqlDatabase.Cats.AsQueryable();

                if (!string.IsNullOrEmpty(breed))
                {
                    catsQuery = catsQuery.Where(cat => cat.Breed == breed);
                }

                if (weight.HasValue)
                {
                    catsQuery = catsQuery.Where(cat => cat.Weight >= weight);
                }

                var cats = await catsQuery.OrderByDescending(cat => cat.Weight).ToListAsync();

                return cats;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while getting cats of {breed} breed and weight from the database", ex);
            }
        }

        public Task<Cat> UpdateCat(Cat updateCat)
        {
            try
            {
                _sqlDatabase.Cats.Update(updateCat);

                _sqlDatabase.SaveChanges();

                return Task.FromResult(updateCat);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a cat by Id {updateCat.AnimalId} from database", ex);
            }
        }
    }
}
