using Infrastructure.Interfaces;
using Domain.Models.AnimalModel;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class DogRepository : GenericRepository<Dog>, IDogRepository
    {
        public DogRepository(RealDb context) : base(context)
        {
        }
        public IEnumerable<Dog> GetDogsOfSameBreedAndCertainWeight(int weight, string breed)
        {
            return _context.Dogs
                .Where(d => d.Breed == breed)
                .Where(d => d.Weight == weight)
                .OrderByDescending(d => d.Weight)
                .ToList();
        }
    }
}
