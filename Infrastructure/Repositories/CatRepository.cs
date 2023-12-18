using Infrastructure.Interfaces;
using Domain.Models.AnimalModel;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        public CatRepository(RealDb context) : base(context) { }

        public IEnumerable<Cat> GetCatsOfSameBreedAndCertainWeight(int weight, string breed)
        {
            return _context.Cats
                .Where(d => d.Breed == breed)
                .Where(d => d.Weight == weight)
                .OrderByDescending(d => d.Weight)
                .ToList();
        }
    }
}
