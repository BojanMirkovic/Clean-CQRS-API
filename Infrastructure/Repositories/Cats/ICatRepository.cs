using Domain.Models.AnimalModel;

namespace Infrastructure.Repositories.Cats
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCats();
        Task<Cat> GetCatById(Guid id);
        Task<Cat> AddCat(Cat newCat);
        Task<Cat> UpdateCat(Cat updateCat);
        Task<Cat> DeleteCat(Guid id);
        Task<List<Cat>> GetCatsByBreedAndWeight(string breed, int? weight);
    }
}
