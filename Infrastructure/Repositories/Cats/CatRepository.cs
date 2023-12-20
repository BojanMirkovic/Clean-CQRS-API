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

        public Task<List<Cat>> GetCatsOfSameBreedAndCertainWeight(int weight, string breed)
        {
            throw new NotImplementedException();
            //return _context.Cats
            //    .Where(d => d.Breed == breed)
            //    .Where(d => d.Weight == weight)
            //    .OrderByDescending(d => d.Weight)
            //    .ToList();
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
