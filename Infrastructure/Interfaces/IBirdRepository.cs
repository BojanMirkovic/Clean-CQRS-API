using Domain.Models.AnimalModel;

namespace Infrastructure.Interfaces
{
    public interface IBirdRepository : IGenericRepository<Bird>
    {
        IEnumerable<Bird> GetAllBirdsOfSameColor(int count, string color);
    }
}
