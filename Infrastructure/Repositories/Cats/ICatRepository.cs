using Domain.Models.AnimalModel;

namespace Infrastructure.Repositories.Cats
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCats();
        Task<List<Cat>> GetCatsOfSameBreedAndCertainWeight(int weight, string breed);
        Task<Cat> GetCatById(Guid id);
        Task<Cat> AddCat(Cat newCat);
        Task<Cat> UpdateCat(Cat updateCat);
        Task<Cat> DeleteCat(Guid id);
    }
}
