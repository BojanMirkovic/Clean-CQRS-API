using Domain.Models.AnimalModel;

namespace Infrastructure.Interfaces
{
    public interface ICatRepository : IGenericRepository<Cat>
    {
        IEnumerable<Cat> GetCatsOfSameBreedAndCertainWeight(int weight, string breed);
    }
}
