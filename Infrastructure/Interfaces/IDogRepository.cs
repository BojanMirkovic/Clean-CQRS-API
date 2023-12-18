using Domain.Models.AnimalModel;

namespace Infrastructure.Interfaces
{
    public interface IDogRepository : IGenericRepository<Dog>
    {
        IEnumerable<Dog> GetDogsOfSameBreedAndCertainWeight(int weight, string breed);
    }
}
