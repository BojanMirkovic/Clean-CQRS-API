using Infrastructure.Interfaces;
using Domain.Models.AnimalModel;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class BirdRepository : GenericRepository<Bird>, IBirdRepository
    {
        public BirdRepository(RealDb context) : base(context)
        {
        }
        public IEnumerable<Bird> GetAllBirdsOfSameColor(int count, string color)
        {
            return _context.Birds
            .Where(b => b.Color == color) // Filtering by color
            .OrderByDescending(b => b.Color)
            .Take(count)
            .ToList();
        }
    }
}
